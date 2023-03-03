using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using System.Diagnostics;

using iVan.Model;

namespace iVan
{
    public partial class ivanFrm : Form
    {
        public ivanFrm()
        {
            InitializeComponent();
        }

        #region Properties

        System.Timers.Timer oTimer = null;
        private int EvaluationPeriod { get; set; }
        private List<Account> accountDta { get; set; }
        private DateTime nextDay { get; set; }

        private Thread th;

        static bool doOperation;

        #endregion

        private void ivanFrm_Load(object sender, EventArgs e)
        {
            try
            {
                
                this.InitializeSystemTimer();
            }
            catch { }
        }

        private void InitializeSystemTimer()
        {
            try
            {
                this.nextDay = DateTime.Now;
                this.EvaluationPeriod = int.Parse(ConfigurationManager.AppSettings["EvaluationPeriod"].ToString());

                this.oTimer = new System.Timers.Timer(this.EvaluationPeriod);
                this.oTimer.AutoReset = true;
                this.oTimer.Enabled = true;
                this.oTimer.Start();

                this.oTimer.Elapsed += new System.Timers.ElapsedEventHandler(EOD_BALANCE_MODULE);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
        }

        private void EOD_BALANCE_MODULE(object sender, System.Timers.ElapsedEventArgs e)
        { 
            //method gets called frequently to move data from Oracle replication server to the CLIREC Staging environment
            th = new Thread(()=>ExecuteETLRoutine());
            th.Name = @"EOD_Balances_Thread";
            th.Priority = ThreadPriority.Highest;
            th.Start();
        }

        private void ExecuteETLRoutine() { 
            //executes the ETL routing for EOD account balances
            //run on a different thread

            /*
             * check if time is 4:00AM or beyond
             * check if doOpertion flag is false before executing
             * execute if it is false
             * make sure data fetched from Oracle is minimum 15,000 records
             * execute procedure
             * flag doOperation as true
            */

            //if (th.IsAlive == false)
            //{
                try
                {
                    var minimumAcct = int.Parse(ConfigurationManager.AppSettings["MinAccount"].ToString());

                    if (this.nextDay == DateTime.Now) { doOperation = true; } else { doOperation = false; }

                    if (isWithinTime() & (doOperation == true))
                    {
                        var obj = new Account() { };
                        int tot_ = obj.getTotalRecordNumber();
                        this.accountDta = obj.getAccountRecords();

                        if (this.accountDta.Count() >= minimumAcct)
                        {
                            //save record to the staging environment
                            int success = 0;
                            int failed = 0;

                            string statusMsg = string.Empty;

                            foreach (var ac in this.accountDta)
                            {
                                try
                                {
                                    lvOperation.Invoke((MethodInvoker)delegate
                                    {
                                        lvOperation.Items.Add(string.Format("Saving record: /Acct No: {0} / Acct Balance: {1}", ac.recId, ac.AcctBalance.ToString()));
                                    });
                                    
                                    if (ac.saveAccountRecord())
                                    {
                                        statusMsg = string.Format("Data points of account {0} saved successfully on {1}", ac.recId, DateTime.Now.ToShortDateString());
                                        success += 1;
                                        //Thread.Sleep(1000);
                                    }
                                    else
                                    {
                                        statusMsg = string.Format("Error saving data of account {0} on {1}", ac.recId, DateTime.Now.ToShortDateString());
                                        failed += 1;
                                    }

                                    lvOperation.Invoke((MethodInvoker)delegate
                                    {
                                        lvOperation.Items.Add(statusMsg);
                                        //lvOperation.Items.Insert(0, statusMsg);
                                        //Thread.Sleep(1000);
                                    });

                                    lblActionStatus.Invoke((MethodInvoker)delegate
                                    {
                                        lblActionStatus.Text = string.Format("Total Records: {0}, successful inserts: {1}, failed inserts: {2}", this.accountDta.Count().ToString(), success.ToString(), failed.ToString());
                                    });
                                }
                                catch { }
                            }

                            //change doOperation flag
                            doOperation = false;
                            this.nextDay = this.nextDay.AddDays(1);
                        }
                        else
                        {
                            //not all records were fetched. clear the collection and try again
                            this.accountDta.Clear();
                        }
                    }
                }
                catch (Exception x)
                {
                    Debug.Print(x.Message);
                }
            //}
        }

        #region Private Helper Methods

        private bool isWithinTime() {
            try
            {
                int MaxT = int.Parse(ConfigurationManager.AppSettings["MaxTime"].ToString());
                int MinT = int.Parse(ConfigurationManager.AppSettings["MinTime"].ToString());

                var date = DateTime.Now;
                if (date.Hour >= MinT & date.Hour < MaxT)
                {
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        #endregion

    }
}
