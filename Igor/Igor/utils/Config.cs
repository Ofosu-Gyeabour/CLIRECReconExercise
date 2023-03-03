using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Igor.Bridge;

namespace Igor.utils
{
    public class Config
    {
        public Config() { }

        #region Properties

        public int interVal { get; set; }
        public string UNC { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

        #endregion

        #region Method

        public Config getConfigObject()
        {
            Config c = null;

            try
            {
                var connstring = ConfigurationManager.ConnectionStrings["SQL_igor"].ToString();

                using (var con = Connectors.createGenericConnection(connstring))
                {
                    var cd = new SqlCommand(@"select * from dbo.__config__;", con);

                    using (var d = cd.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            c = new Config();

                            d.Read();

                            c.interVal = int.Parse(d["freq_"].ToString());
                            c.UNC = d["storage_"].ToString();
                            c.userName = d["usr"].ToString();
                            c.userPassword = d["pwd"].ToString();

                            return c;
                        }
                        else { return c; }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
        }

        #endregion

    }

}
