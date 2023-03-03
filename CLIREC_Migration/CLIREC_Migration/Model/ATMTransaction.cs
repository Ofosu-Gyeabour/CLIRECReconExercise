using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Diagnostics;

using CLIREC_Migration.Bridge;

namespace CLIREC_Migration.Model
{
    public class ATMTransaction
    {
        #region Properties

        public int Id { get; set; }
        public string REKORDID { get; set; }
        public DateTime transactionDate { get; set; }
        public DateTime businessDate { get; set; }
        public string transactionTime { get; set; }
        public string traceNumber { get; set; }
        public string referenceNo { get; set; }
        public string ATM_ID { get; set; }
        public decimal Amount { get; set; }
        public string debitAccountNumber { get; set; }
        public string creditAccountNumber { get; set; }
        public DateTime uploadedDate { get; set; }

        public string filePath { get; set; }

        #endregion

        #region Methods

        public List<ATMTransaction> getExcelATMTransactions() {

            List<ATMTransaction> record = null;

            try
            {
                //var connstring = ConfigurationManager.ConnectionStrings["SQL_test"].ToString();

                using (var con = Connectors.getExcelConnection(this.filePath)) {
                    var cmd = new OleDbCommand() { 
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = @"select * from [Data$]",
                        CommandTimeout = 30
                    };

                    using (var d = cmd.ExecuteReader()) {
                        if (d.HasRows)
                        {
                            int k = 1;
                            record = new List<ATMTransaction>();
                            while (d.Read()) {

                                var obj = new ATMTransaction() 
                                { 
                                    Id = k,
                                    REKORDID = d["RECID"].ToString(),
                                    transactionDate = this.formatAsDate(d["TransactionDate"].ToString().Trim()),
                                    businessDate = this.formatAsDate(d["BusinessDate"].ToString().Trim()),
                                    transactionTime = this.formatAsTime(d["transactionTime"].ToString().Trim()),
                                    traceNumber = d["TraceNo"].ToString().Trim(),
                                    referenceNo = d["ReferenceNo"].ToString().Trim(),
                                    ATM_ID = d["ATMID"].ToString().Trim(),
                                    Amount = Convert.ToDecimal(d["Amount"].ToString()),
                                    debitAccountNumber = d["DebitAcctNo"].ToString().Trim(),
                                    creditAccountNumber = d["CreditAcctNo"].ToString().Trim()
                                };

                                record.Add(obj);
                                k += 1;
                            }

                            return record.ToList<ATMTransaction>();
                        }
                        else { return record; }
                    }
                }
            }
            catch (Exception x) 
            {
                Debug.Print(x.Message);
                return record;
            }
        }

        private DateTime formatAsDate(string strRecord) {
            var YY = int.Parse(strRecord.Substring(0, 4));
            var M = int.Parse(strRecord.Substring(4, 2));
            var dd = int.Parse(strRecord.Substring(6, 2));

            var date_ = new DateTime(YY, M, dd);
            return date_;
        }

        private string formatAsTime(string strRecord) { 
            //format data as time
            var _data = strRecord.Substring(6, 4);
            var HH = _data.Substring(0, 2);
            var mm = _data.Substring(2, 2);

            return string.Format("{0}:{1}", HH, mm);
        }

        public bool saveRecord() {
            try
            {
                var connstring = ConfigurationManager.ConnectionStrings["SQL_conn"].ToString();
                using (var con = Connectors.createGenericConnection(connstring)) {
                    var cmd = new SqlCommand() { 
                        Connection =con,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = @"[proc_ATMTxn_i]",
                        CommandTimeout = 30
                    };

                    //params
                    cmd.Parameters.AddWithValue("@rec", this.REKORDID);
                    cmd.Parameters.AddWithValue("@tdate", this.transactionDate);
                    cmd.Parameters.AddWithValue("@bdate", this.businessDate);
                    cmd.Parameters.AddWithValue("@ttime", this.transactionTime);
                    cmd.Parameters.AddWithValue("@trace", this.traceNumber);
                    cmd.Parameters.AddWithValue("@ref", this.referenceNo);
                    cmd.Parameters.AddWithValue("@atmID", this.ATM_ID);
                    cmd.Parameters.AddWithValue("@amt", this.Amount);
                    cmd.Parameters.AddWithValue("@debitAcc", this.debitAccountNumber);
                    cmd.Parameters.AddWithValue("@creditAcc", this.creditAccountNumber);
                    cmd.Parameters.AddWithValue("@dte_uploaded", DateTime.Now);
                    cmd.Parameters.AddWithValue("@readStatus", 0);

                    this.Id = int.Parse(cmd.ExecuteScalar().ToString());

                    return (this.Id > 0 ? true : false);
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return false;
            }
        }

        #endregion


    }
}
