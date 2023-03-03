using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;
using System.Configuration;
using CLIREC_Migration.Bridge;

namespace CLIREC_Migration.Model
{
    public class JDates
    {
        #region Properties

        public int Id { get; set; }
        public string periodFrom { get; set; }
        public string periodTo { get; set; }
        public string julianFrom { get; set; }
        public string julianTo { get; set; }
        public int migration_status { get; set; }

        #endregion

        #region Methods

        public List<JDates> getJulianConfiguration() { 
            //gets julian configured dates from the data store
            List<JDates> rs = null;

            try
            {
                var connstring = ConfigurationManager.AppSettings["SQL_conn"].ToString();
                using (var con = Connectors.createGenericConnection(connstring)) {
                    var cmd = new SqlCommand() { 
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = @"select * from dbo.Dte_Configuration where status = @stat order by Id;",
                        CommandTimeout = 20
                    };

                    cmd.Parameters.AddWithValue("@stat", @"0");

                    using (var d = cmd.ExecuteReader()) {
                        if (d.HasRows)
                        {
                            rs = new List<JDates>();
                            while (d.Read()) {
                                var obj = new JDates() { 
                                    Id = int.Parse(d["Id"].ToString()),
                                    periodFrom = d["pfrom"].ToString(),
                                    periodTo = d["pto"].ToString(),
                                    julianFrom = d["julianFrom"].ToString(),
                                    julianTo = d["julianTo"].ToString(),
                                    migration_status = int.Parse(d["status"].ToString())
                                };

                                rs.Add(obj);
                            }

                            return rs.ToList<JDates>();
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

        #endregion

    }

    public class JConfig {

        public int interVal { get; set; }
        public DateTime referenceDate { get; set; }
        public int julianRef { get; set; }

        public JConfig getConfigurationInfo() {
            JConfig obj = null;

            try
            {
                string connstring = ConfigurationManager.ConnectionStrings["SQL_conn"].ToString();
                using (var conn = Connectors.createGenericConnection(connstring))
                {
                    var cmd = new SqlCommand(@"select * from dbo.__config__;", conn);

                    using (var d = cmd.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            d.Read();
                            obj = new JConfig()
                            {
                                interVal = int.Parse(d["intV"].ToString()),
                                referenceDate = Convert.ToDateTime(d["refD"].ToString()),
                                julianRef = int.Parse(d["refJ"].ToString())
                            };

                            return obj;
                        }
                        else { return obj; }
                    }
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
                return obj;
            }
        }

    }
}
