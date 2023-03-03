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
using System.Configuration;

using CLIREC_Migration.Bridge;

namespace CLIREC_Migration.Model
{
    public class Account
    {
        #region Properties

        public string recId { get; set; }
        public string shortTitle { get; set; }
        public string co_code { get; set; }
        public string xmlRecord { get; set; }

        public int BATCHSIZE { get; set; }

        public string param1 { get; set; }
        public string param2 { get; set; }
        public double? AcctBalance { get; set; }
        public string dbl { get; set; }

        #endregion

        #region Methods

        public int getTotalRecordNumber() {
            int tot = 0;

            try
            {
                using (var conn = Connectors.getOracleConnection()) {
                    var cmd = new OracleCommand { 
                        Connection = conn,
                        CommandType = CommandType.Text,
                        //CommandText = @"select count(*) from t24prd.fbnk_account where recid between '"+ this.param1 +"' and '"+ this.param2 +"'",
                        CommandText = @"select count(*) from t24prd.fbnk_account",
                        CommandTimeout = 20
                    };

                    tot = int.Parse(cmd.ExecuteScalar().ToString());
                    return tot;
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return tot;
            }
        }

        public bool saveAccountRecord() { 
            //saves account record in the EOD_Balance table
            try
            {
                var connstring = ConfigurationManager.ConnectionStrings["SQL_conn"].ToString();
                using (var conn = Connectors.createGenericConnection(connstring)) {
                    var cmd = new SqlCommand() { 
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = @"[proc_eodBal_i]",
                        CommandTimeout = 30
                    };

                    cmd.Parameters.AddWithValue("@acct", this.recId);
                    cmd.Parameters.AddWithValue("@acctBal", this.AcctBalance);
                    cmd.Parameters.AddWithValue("@dte", DateTime.Now);
                    cmd.Parameters.AddWithValue("@r", 0);

                    var _id = int.Parse(cmd.ExecuteScalar().ToString());

                    return _id > 0 ? true : false;
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return false;
            }
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

        public List<Account> getAccountRecords() {
            List<Account> rs = null;
            int i = 0;
            var ghs = @"GHS";
            var usd = @"USD";
            var gbp = @"GBP";
            var eur = @"EUR";

            try
            {
                using (var conn = Connectors.getOracleConnection()) {
                    var cmd = conn.CreateCommand();

                    cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = @"select recid,xmlrecord from t24prd.FBNK_ACCOUNT where recid between '" + this.param1 + "' and '"+ this.param2 +"'";
                    cmd.CommandText = @"select RECID,EXTRACTVALUE(xmlrecord,'/row/c23[1]/text()'),EXTRACTVALUE(xmlrecord,'/row/c1[1]/text()') from t24prd.FBNK_ACCOUNT where RECID like '"+ ghs + "%' or RECID like '"+ usd + "%' or RECID like '"+ gbp +"%' or RECID like '"+ eur +"%'";
                    cmd.CommandTimeout = 30;

                    using(var d = cmd.ExecuteReader()){
                        if (d.HasRows)
                        {
                            rs =new List<Account>();

                            try
                            {
                                while (d.Read())
                                {
                                    if (i == 6944)
                                    {
                                        var s = @"testing";
                                    }
                                    else { var s = string.Empty; }
                                    try
                                    {
                                        var str = Convert.ToString(d[2].ToString());
                                        if (str == string.Empty)
                                        {
                                            var obj = new Account() { };

                                            obj.recId = d[0].ToString();
                                            obj.dbl = Convert.ToString(d[1].ToString());

                                            try
                                            {
                                                if (string.IsNullOrEmpty(obj.dbl))
                                                {
                                                    obj.AcctBalance = 0;
                                                }
                                                else { obj.AcctBalance = Convert.ToDouble(obj.dbl); }
                                            }
                                            catch { obj.AcctBalance = 0; }

                                            rs.Add(obj);
                                            i += 1;
                                        }
                                    }
                                    catch (Exception z)
                                    {
                                        Debug.Print(z.Message);
                                        return rs;
                                    }
                                }

                                return rs.ToList<Account>();
                            }
                            catch (Exception er) {
                                Debug.Print(er.Message);
                                return rs;
                            }
                        }
                        else{ return rs;}
                    }
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return rs;
            }
        }

        #endregion

    }
}
