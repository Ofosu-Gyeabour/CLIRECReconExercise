using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

using Igor.Bridge;

namespace Igor.utils
{
    public static class Logfile
    {
        public static bool writeEntry(string msg, DateTime dte, string folderName)
        {
            try
            {
                var connstring = ConfigurationManager.ConnectionStrings["SQL_igor"].ToString();
                using (var con = Connectors.createGenericConnection(connstring))
                {
                    var cmd = new SqlCommand
                    {
                        Connection = con,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = @"[Log_i]",
                        CommandTimeout = 20
                    };

                    cmd.Parameters.AddWithValue("@msg", msg);
                    cmd.Parameters.AddWithValue("@dte", dte);
                    cmd.Parameters.AddWithValue("@folder", folderName);


                    var _id = int.Parse(cmd.ExecuteScalar().ToString());

                    return (_id > 0 ? true : false);
                }
            }
            catch { throw; }
        }
    }
}
