using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Net;

namespace CLIREC_Migration.Model
{
    public class Error
    {
        public string message { get; set; }

        public void LogError() {
            try
            {
                string path = ConfigurationManager.AppSettings["errorLog"].ToString();
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(message);
                    writer.Close();
                }
            }
            catch (Exception x) {
                Debug.Print(x.Message);
            }
            
        }

    }
}
