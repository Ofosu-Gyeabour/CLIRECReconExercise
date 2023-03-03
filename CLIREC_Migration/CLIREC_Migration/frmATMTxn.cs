using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CLIREC_Migration.Model;
using System.Threading;

namespace CLIREC_Migration
{
    public partial class frmATMTxn : Form
    {
        public frmATMTxn()
        {
            InitializeComponent();
        }

        private string PATH_TO_FILE = @"C:\Users\Blessings\Desktop\T24ATM_TRANS.xlsx";

        private void btnTxnData_Click(object sender, EventArgs e)
        {
            try
            {
                Thread th = new Thread(()=>LoadData());
                th.Priority = ThreadPriority.Normal;
                th.Start();
            }
            catch (Exception x) { }
        }

        private void LoadData() {
            try
            {
                var dta = new ATMTransaction() { filePath = this.PATH_TO_FILE }.getExcelATMTransactions();

                if (dta != null) {
                    int i = 0;
                    int f = 0;

                    foreach (var d in dta) {
                        if (d.saveRecord()) { i++; } else { f++; }

                        lblStatus.Invoke((MethodInvoker)delegate {
                            lblStatus.Text = string.Format("Total Records = {0}, Successful inserts = {1}, Failed inserts = {2}", dta.Count().ToString(), i.ToString(), f.ToString());
                        });
                    }
                }
            }
            catch (Exception error) {
                throw error;
            }
        }
    }
}
