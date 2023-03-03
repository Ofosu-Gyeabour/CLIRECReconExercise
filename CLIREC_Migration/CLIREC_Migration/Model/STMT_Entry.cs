using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;
using Oracle.ManagedDataAccess.Client;

using CLIREC_Migration.Bridge;
using System.Configuration;

namespace CLIREC_Migration.Model
{
    public class STMT_Entry
    {
        #region Properties

        public string RECID { get; set; }
        public string xmlRecord { get; set; }
        public double Amt { get; set; }
        public string AmtDirection { get; set; }
        public string valueDate { get; set; }
        public string postDate { get; set; }
        public string accountNo { get; set; }
        public string narrative { get; set; }
        public string transReference { get; set; }

        public string param1 { get; set; }
        public string param2 { get; set; }

        public int BATCHSIZE { get; set; }

        public static string RECID_POINTER;

        #endregion

        #region Methods

        public List<STMT_Entry> getSTMTEntryRecords(string sflag) {
            List<STMT_Entry> rs = null;
            try
            {
                using (var conn = Connectors.getOracleConnection()) {
                    var cmd = conn.CreateCommand();
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 60;

                    if (sflag == @"init")
                    {
                        cmd.CommandText = @"select recid,EXTRACTVALUE(xmlrecord,'/row/c3/text()'), EXTRACTVALUE(xmlrecord, '/row/c11/text()'), EXTRACTVALUE(xmlrecord,'/row/c25/text()'), EXTRACTVALUE(xmlrecord,'/row/c1/text()'), EXTRACTVALUE(xmlrecord,'/row/c23/text()'), xmlrecord  FROM t24prd.FBNK_STMT_ENTRY where RECID BETWEEN '" + this.param1 + "' and '" + this.param2 + "'";
                    }
                    else if (sflag == @"continuation")
                    { 
                            //generate starting RECID and give it to param1
                        var _value = this.generateNextRecID();
                        this.param1 = _value;
                        cmd.CommandText = @"select recid,EXTRACTVALUE(xmlrecord,'/row/c3/text()'), EXTRACTVALUE(xmlrecord, '/row/c11/text()'), EXTRACTVALUE(xmlrecord,'/row/c25/text()'), EXTRACTVALUE(xmlrecord,'/row/c1/text()'), EXTRACTVALUE(xmlrecord,'/row/c23/text()'), xmlrecord FROM t24prd.FBNK_STMT_ENTRY where RECID BETWEEN '" + this.param1 + "' and '" + this.param2 + "'";
                    }

                    using (var d = cmd.ExecuteReader()) {
                        if (d.HasRows)
                        {
                            int k = 0;
                            rs = new List<STMT_Entry>();
                            while (d.Read()) 
                            {
                                if (k < this.BATCHSIZE)  //batch size not exceeded..pull
                                {
                                    var o = new STMT_Entry(){};

                                    
                                        o.RECID = d[0].ToString();
                                        o.Amt = Convert.ToDouble(d[1].ToString());
                                        o.valueDate = d[2].ToString();
                                        o.postDate = d[3].ToString();
                                        o.accountNo = d[4].ToString();
                                        
                                        o.transReference = d[5].ToString();
                                        o.narrative = o.transReference;
                                        //o.narrative =  string.IsNullOrEmpty(d[6].ToString()) ? string.Empty: d[6].ToString();
                                       
                                    rs.Add(o);
                                    RECID_POINTER = o.RECID;
                                    k += 1;
                                }
                                else 
                                { 
                                    
                                    return rs.ToList<STMT_Entry>(); 
                                }
                            }

                            return rs.ToList<STMT_Entry>();
                        }
                        else { return rs; }
                    }
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return rs;
            }
        }

        public string generateNextRecID() { 
            //method is responsible for generating the next RECID
            var str = RECID_POINTER.Split('.');
            var apdx = Convert.ToInt64( str[1]);
            string retString = string.Empty;

            apdx += 1;

            switch (apdx.ToString().Length) 
            { 
                case 6:
                    retString = apdx.ToString();
                    break;
                case 5:
                    retString = string.Format("{0},{1}", @"0", apdx.ToString());
                    break;
                case 4:
                    retString = string.Format("{0},{1}", @"00", apdx.ToString());
                    break;
                case 3:
                    retString = string.Format("{0},{1}", @"000", apdx.ToString());
                    break;
                case 2:
                    retString = string.Format("{0},{1}", @"0000", apdx.ToString());
                    break;
                case 1:
                    retString = string.Format("{0},{1}", @"00000", apdx.ToString());
                    break;
            }

            //re-format ID
            return string.Format("{0}.{1}", str[0], retString);
        }

        public int getCount() { 
            //get reference data
            //deduce reference numbers
            //gets count of the data to pull

            try
            {
                    using (var conn = Connectors.getOracleConnection())
                    {
                        var cmd = conn.CreateCommand();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"select count(*) from t24prd.FBNK_STMT_ENTRY where RECID BETWEEN '" + this.param1 + "' and '" + this.param2 + "'";
                        cmd.CommandTimeout = 60;

                        int count = int.Parse(cmd.ExecuteScalar().ToString());
                        return count;
                    }
            }
            catch (Exception x)
            {
                Debug.Print(x.Message);
                return 0;
            }
        }

        public bool saveRecord() { 
            //method is used to save record into the data store
            try
            {
                //this.narrative = string.Empty;
                var connstring = ConfigurationManager.ConnectionStrings["SQL_conn"].ToString();

                using (var conn = Connectors.createGenericConnection(connstring)) {
                    var cmd = new SqlCommand() { 
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = @"[proc_txnData_iprod]",
                        CommandTimeout = 30
                    };


                    this.AmtDirection = getAmtDirection(this.Amt);
                    if (this.postDate != string.Empty) { }
                    //params
                    cmd.Parameters.AddWithValue("@recID", this.RECID);
                    cmd.Parameters.AddWithValue("@tRef", this.transReference);
                    cmd.Parameters.AddWithValue("@acctNo", this.accountNo);
                    cmd.Parameters.AddWithValue("@postDte", string.IsNullOrEmpty(this.postDate)? (DateTime?) null: Convert.ToDateTime(formatDateString(this.postDate)) );
                    cmd.Parameters.AddWithValue("@valueDte", string.IsNullOrEmpty(this.valueDate) ? (DateTime?)null : Convert.ToDateTime(formatDateString(this.valueDate)));
                    cmd.Parameters.AddWithValue("@detail", this.narrative);
                    cmd.Parameters.AddWithValue("@amt", this.Amt);
                    cmd.Parameters.AddWithValue("@amtD", this.AmtDirection);
                    cmd.Parameters.AddWithValue("@dte_uploaded", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status", 0);

                    var _Id = int.Parse(cmd.ExecuteScalar().ToString());
                    return _Id > 0 ? true : false;
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return false;
            }
        }

        public List<STMT_Entry> getTxnDuplicates() { 
            //method gets all duplicate transactions in the data store
            List<STMT_Entry> rs = null;

            try
            {
                var connstring = ConfigurationManager.AppSettings["SQL_conn"].ToString();
                using (var conn = Connectors.createGenericConnection(connstring)) {
                    var cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandType = CommandType.Text,
                        CommandText = @"select * from dbo.vw_counterprod",
                        CommandTimeout = 20
                    };

                    using (var d = cmd.ExecuteReader()) {
                        if (d.HasRows)
                        {
                            rs = new List<STMT_Entry>();
                            //int _id = 0;
                            while (d.Read()) {
                                var o = new STMT_Entry { RECID = d["RECID"].ToString(), BATCHSIZE = int.Parse(d["totalNum"].ToString()) };
                                rs.Add(o);
                            }

                            return (rs.ToList<STMT_Entry>());
                        }
                        else { return rs; }
                    }
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return rs;
            }
        }

        public bool executeTxnPurgingProcess() { 
            //get the count of duplicates
            //remove excess
            int k = 0;
            try
            {
                var txns = this.selectTxnToDelete(this.BATCHSIZE);  //BATCHSIZE is used to store the number of duplicate counts
                if (txns.Count() > 1) {
                    k = this.delete(txns);
                }

                return k == txns.Count() ? true : false;
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return false;
            }
        }

        private int delete(int[] arr) {
            //deletes records with recordID in the array argument
            int z = 0;
            try
            {
                var connstring = ConfigurationManager.AppSettings["SQL_conn"].ToString();
                using (var conn = Connectors.createGenericConnection(connstring)) {
                    
                        foreach (var a in arr)
                        {
                            try
                            {
                                var cmd = new SqlCommand(@"delete from dbo.Txn_data_prod where Id = @id;", conn);
                                cmd.Parameters.AddWithValue("@id", int.Parse(a.ToString()));

                                cmd.ExecuteNonQuery();
                                z += 1;
                            }
                            catch (Exception err) { }
                        }

                        return z;
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return z;
            }
        }

        private int[] selectTxnToDelete(int counter) {
            try
            {
                int[] r = new int[counter];
                var connstring = ConfigurationManager.AppSettings["SQL_conn"].ToString();
                using (var conn = Connectors.createGenericConnection(connstring)) {
                    var cmd = new SqlCommand(@"select Id from dbo.txn_data_prod where recid = @r", conn);
                    cmd.Parameters.AddWithValue("@r", this.RECID);

                    using (var d = cmd.ExecuteReader()) {
                        if (d.HasRows)
                        {
                            //d.Read();
                            int _id = 0;
                            while (d.Read()) {
                                if (_id > 0)
                                {
                                    r[_id] = int.Parse(d["Id"].ToString());
                                }

                                _id += 1;
                            }

                            return r;
                        }
                        else { r = null; return r; } 

                    }
                }
            }
            catch (Exception x) {
                throw x;
            }
        }

        private string getAmtDirection(double amt) {
            return amt > 0 ?  @"CREDIT" : @"DEBIT";
        }

        private string formatDateString(string inputString)
        {
            try
            {
                var year = inputString.Substring(0, 4);
                var mnt = inputString.Substring(4, 2);
                var dd = inputString.Substring(6, 2);

                return string.Format("{0}-{1}-{2}", year, mnt, dd);
            }
            catch (Exception x)
            {
                Debug.Print(x.Message);
                throw x;
            }
        }

        #region Delete-After

        public bool findRecordByID() { 
            //method is used to find a record using the RECID field
            try
            {
                var connstring = ConfigurationManager.ConnectionStrings["SQL_conn"].ToString();
                using (var con = Connectors.createGenericConnection(connstring)) {
                    var cmd = new SqlCommand() { 
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = @"select count(*) from dbo.txn_data where RECID = @recid;",
                        CommandTimeout = 30
                    };

                    cmd.Parameters.AddWithValue("@recid", this.RECID);

                    int _count = int.Parse(cmd.ExecuteScalar().ToString());

                    return (_count > 0 ? true : false);
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return false;
            }
        }

        #endregion


        #endregion


    }
}
