using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using CLIREC_Migration.Model.DataSource;
using CLIREC_Migration.Bridge;

namespace CLIREC_Migration.Model.DataSource
{
    public class RECXLFile
    {
        #region Properties

        public int Id { get; set; }
        public string REKORD_ID { get; set; }

        public string filePath { get; set; }

        #endregion

        #region Methods

        public List<RECXLFile> LoadExcelFile() {
            List<RECXLFile> results = null;

            try
            {
                using (var con = Connectors.getXLSXConnection(this.filePath)) {
                    var cmd = new OleDbCommand() { 
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = @"select * from [RECIDs$]",
                        CommandTimeout = 30
                    };

                    using (var d = cmd.ExecuteReader()) {
                        if (d.HasRows)
                        {
                            results = new List<RECXLFile>();
                            while (d.Read()) 
                            {
                                var o = new RECXLFile() { 
                                    Id = int.Parse(d["ID"].ToString()),
                                    REKORD_ID = d["RECORD_ID"].ToString() 
                                };

                                results.Add(o);
                            }

                            return results.ToList<RECXLFile>();
                        }
                        else { return results; }
                    }
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return new List<RECXLFile>();
            }
        }

        #endregion


    }

    public class DriverTestTakers
    {

        #region Properties

        public int Id { get; set; }
        public string staffNumber { get; set; }
        public string staffName { get; set; }

        public string filePath { get; set; }

        #endregion

        #region Methods

        public List<DriverTestTakers> LoadExcelFile()
        {
            List<DriverTestTakers> results = null;

            try
            {
                using (var con = Connectors.getXLSXConnection(this.filePath))
                {
                    var cmd = new OleDbCommand()
                    {
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = @"select * from [List$]",
                        CommandTimeout = 30
                    };

                    using (var d = cmd.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            results = new List<DriverTestTakers>();
                            while (d.Read())
                            {
                                var o = new DriverTestTakers()
                                {
                                    Id = int.Parse(d["No"].ToString()),
                                    staffNumber = d["StaffID"].ToString().Trim(),
                                    staffName = string.Format("{0} {1} {2}",@"Mr", d["FirstNames"].ToString().Trim(),d["LastName"].ToString().Trim())
                                };

                                results.Add(o);
                            }

                            return results.ToList<DriverTestTakers>();
                        }
                        else { return results; }
                    }
                }
            }
            catch (Exception x)
            {
                Debug.Print(x.Message);
                return new List<DriverTestTakers>();
            }
        }

        public bool PostRecord() { 
            //method is responsible for posting record into the data store
            try
            {
                var connstring = ConfigurationManager.ConnectionStrings["AML_conn"].ToString();
                using (var con = Connectors.createGenericConnection(connstring)) {
                    var cmd = new SqlCommand() { 
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = @"insert into dbo.staffexamdetails values(@stNo,@stName,@stDept,@rScore,@aScore,@tID); select @@identity as Id;",
                        CommandTimeout = 30
                    };

                    //params
                    cmd.Parameters.AddWithValue("@stNo", this.staffNumber);
                    cmd.Parameters.AddWithValue("@stName", this.staffName);
                    cmd.Parameters.AddWithValue("@stDept", @"Transport Unit");
                    cmd.Parameters.AddWithValue("@rScore", 10);
                    cmd.Parameters.AddWithValue("@aScore", 1);
                    cmd.Parameters.AddWithValue("@tID", 1);

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
