using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using CLIREC_Migration.Bridge;
using CLIREC_Migration.Model;
using System.Threading;

namespace CLIREC_Migration
{
    public partial class frmCLIREC_Center : Form
    {
        Thread th;
        private int TOTAL_RECORDS;

        public frmCLIREC_Center()
        {
            InitializeComponent();
        }

        public List<Account> accountDta;

        private void frmCLIREC_Center_Load(object sender, EventArgs e)
        {
            try
            {
                LoadJulianDates();
            }
            catch (Exception x) { }
        }

        private void LoadAccountData() { 
            //method is responsible for loading accounts data
            try
            {
                var tot_ = new Account() { param1 = txtJulianFrom.Text, param2 = txtJulianTo.Text }.getTotalRecordNumber();
                lblstatus.Invoke((MethodInvoker)delegate {
                    lblstatus.Text = string.Format("Total records fetched: {0}",tot_.ToString() );
                });

                this.accountDta = new Account { param1 = txtJulianFrom.Text.Trim(), param2 = txtJulianTo.Text.Trim(), BATCHSIZE = tot_ }.getAccountRecords();
                if (this.accountDta != null) {
                    lblActionStatus.Invoke((MethodInvoker)delegate
                    {
                        lblActionStatus.Text = string.Format("{0} Account Balances loaded...waiting for next action...", this.accountDta.Count().ToString());
                    });
                }
                return;


                if (this.accountDta != null)
                {
                    var knt = 0;

                    foreach (var item in this.accountDta)
                    {
                        this.lvDetails.Invoke((MethodInvoker)delegate {
                            ListViewItem L = new ListViewItem(item.recId);
                            L.SubItems.Add(item.xmlRecord);

                            this.lvDetails.Items.Add(L);
                        });
                        
                        knt += 1;

                        lblActionStatus.Invoke((MethodInvoker)delegate {
                            lblActionStatus.Text = string.Format("{0} loaded.waiting for action...", knt.ToString());
                        });
                    }
                }
            }
            catch (Exception x) {
                throw x;
            }
        }

        private bool validateParams() {
            err.Clear();
            if ((txtJulianFrom.Text == string.Empty) || (txtJulianTo.Text == string.Empty) || (txtInterval.Text == string.Empty))
            {
                if (txtJulianFrom.Text == string.Empty) { err.SetError(txtJulianFrom, "Please select julian date to start fetching from"); }
                if (txtJulianTo.Text == string.Empty) { err.SetError(txtJulianTo, "Please select julian date to end fetching from"); }
                if (txtInterval.Text == string.Empty) { err.SetError(txtInterval, "Please select BATCHSIZE of records to fetch"); }
                return false;
            }
            else return true;
        }

        private void btnFetchAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validateParams())
                {
                    th = new Thread(() => LoadAccountData());
                    th.Priority = ThreadPriority.Highest;
                    th.Start();
                }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private void lvDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               var str = lvDetails.SelectedItems[0].SubItems[1].Text;
               txtHighlighted.Text = str;
            }
            catch (Exception x) {
                //MessageBox.Show(x.Message);
            }
        }

        private void LoadJulianDates() { 
            //this method is responsible for the loading of Julian dates from the data store
            try
            {
                var jData = new JDates() { }.getJulianConfiguration();
                if (jData != null) {
                    foreach (var jd in jData) {
                        var L = new ListViewItem(jd.Id.ToString());
                        L.SubItems.Add(jd.periodFrom);
                        L.SubItems.Add(jd.periodTo);
                        L.SubItems.Add(jd.julianFrom);
                        L.SubItems.Add(jd.julianTo);

                        this.lvStatistics.Items.Add(L);
                    }
                }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private void lvStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtJulianFrom.Text = lvStatistics.SelectedItems[0].SubItems[3].Text;
                txtJulianTo.Text = lvStatistics.SelectedItems[0].SubItems[4].Text;
            }
            catch (Exception x) { }
        }

        private void btnDataStore_Click(object sender, EventArgs e)
        {
            try
            {
                th = new Thread(()=>PostAccountData());
                th.Name = @"PostAccountData";
                th.Priority = ThreadPriority.Highest;
                th.Start();
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private void PostAccountData() {
            try
            {
                if (this.accountDta != null) {
                    int i = 0;
                    int f = 0;

                    foreach (var a in this.accountDta) 
                    {                   
                        try
                        {
                            if (a.saveAccountRecord()) { i += 1; } else { f += 1; }
                            lblActionStatus.Invoke((MethodInvoker)delegate
                            {
                                lblActionStatus.Text = string.Format("Total Records: {0}, Success: {1}, Failed: {2}", this.accountDta.Count().ToString(), i.ToString(), f.ToString());
                            });
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }

        
    }
}
