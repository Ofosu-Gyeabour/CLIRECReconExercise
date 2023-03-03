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
using System.Diagnostics;
using System.Threading;
using CLIREC_Migration.Model.DataSource;

namespace CLIREC_Migration
{
    public partial class frmSTMT_Entry : Form
    {
        private Thread th;
        private Thread thDtStorage;

        private static int DataCount;
        private List<STMT_Entry> stmtRecords;
        private List<STMT_Entry> duplicate_data;

        private int recordsLeft;
        private string flag_;

        private int MODULO_COUNT;
        private int MODULO_REMAINDER;

        private List<DriverTestTakers> _data;

        public frmSTMT_Entry()
        {
            InitializeComponent();
        }

        
        private void btnFetchAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateJulianDates())
                {
                    
                    th = new Thread(() => LoadSTMTEntryRecords());
                    th.Priority = ThreadPriority.Highest;
                    th.Start();
                }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private bool validateJulianDates() {
            try
            {
                err.Clear();
                
                //if ((txtJulianFrom.Text == string.Empty) || (txtJulianTo.Text == string.Empty) || (txtInterval.Text == string.Empty))
                if (txtInterval.Text == string.Empty)
                {
                    //if (txtJulianFrom.Text == string.Empty) { err.SetError(txtJulianFrom, "Please enter julian start date"); }
                    //if (txtJulianTo.Text == string.Empty) { err.SetError(txtJulianTo, "Please enter julian end date"); }
                    if (txtInterval.Text == string.Empty) { err.SetError(txtInterval, "Please input the batch size to pull"); }

                    return false;
                }
                else { return true; }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
                return false;
            }
        }

        private string getCurrentJulianDate()
        {
            //method is responsible for getting and computing the current julian date
            try
            {
                int days_ = 0;
                string sRef = string.Empty;

                var jObj = new JConfig() { }.getConfigurationInfo();
                if (jObj != null)
                {
                    days_ = (DateTime.Now - jObj.referenceDate).Days - 1;
                    sRef = (jObj.julianRef + days_).ToString();
                    
                    return sRef;
                }
                else { return string.Empty; }
            }
            catch (Exception x)
            {
                Debug.Print(x.Message);
                return string.Empty;
            }
        }

        private void LoadSTMTEntryRecords() {
            try
            {
                //var strDate = this.getCurrentJulianDate();
                var strDate = @"19696";
                if (strDate != string.Empty)
                {
                    var obj = new STMT_Entry()
                    {
                        param1 = string.Format("{0}{1}.{2}", strDate, @"0000000000", @"000000"),
                        param2 = string.Format("{0}{1}.{2}", strDate, @"9999999999", @"999999"),
                        BATCHSIZE = int.Parse(txtInterval.Text.Trim())
                    };

                    if (this.flag_ == @"init")
                    {
                        //DataCount = new STMT_Entry { param1 = txtJulianFrom.Text.Trim(), param2 = txtJulianTo.Text.Trim() }.getCount();
                        DataCount = obj.getCount();
                    }                    

                    if (STMT_Entry.RECID_POINTER != null)
                    {
                        obj.param1 = STMT_Entry.RECID_POINTER;
                    }

                    lblbatchstatus.Invoke((MethodInvoker)delegate
                    {
                        lblbatchstatus.Text = string.Format("Total Records: {0}", DataCount.ToString());
                    });

                    lblstatus.Invoke((MethodInvoker)delegate
                    {
                        lblstatus.Text = @"Waiting for action...";
                    });


                    if (DataCount == 0 && this.flag_ == @"init") { return; }
                    if (DataCount > 0 && this.flag_ == @"continuation") { this.stmtRecords = obj.getSTMTEntryRecords(this.flag_); }
                    if (DataCount > 0 && this.flag_ == @"init") { this.stmtRecords = obj.getSTMTEntryRecords(this.flag_); this.flag_ = @"continuation"; }


                    txtHighlighted.Invoke((MethodInvoker)delegate
                    {
                        txtHighlighted.Text = STMT_Entry.RECID_POINTER;
                    });

                    if (stmtRecords != null)
                    {
                        lblstatus.Invoke((MethodInvoker)delegate
                        {
                            lblstatus.Text = string.Format("Total of {0} records loaded. Click Push to Data store to proceed", stmtRecords.Count().ToString());
                        });
                        return;

                        var count = 0;

                        foreach (var stmt in stmtRecords)
                        {
                            this.lvDetails.Invoke((MethodInvoker)delegate
                            {

                                lvDetails.Items.Clear();

                                ListViewItem L = new ListViewItem(stmt.RECID);
                                L.SubItems.Add(stmt.transReference);
                                L.SubItems.Add(stmt.accountNo);
                                L.SubItems.Add(stmt.postDate);
                                L.SubItems.Add(stmt.valueDate);
                                L.SubItems.Add(stmt.narrative);
                                L.SubItems.Add(stmt.Amt.ToString());

                                lvDetails.Items.Add(L);

                                count += 1;
                            });

                            lblstatus.Invoke((MethodInvoker)delegate
                            {
                                //lblstatus.Text = string.Empty;
                                lblstatus.Text = string.Format("Loading data from {0}.{1} of out {2} so far loaded.Please wait...", @"FBNK_STMT_ENTRY", count.ToString(), stmtRecords.Count().ToString());
                            });
                        }
                    }
                }
                else { }
            }
            catch (Exception x) {
                throw x;
            }
        }

        private void lvDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var str = lvDetails.SelectedItems[0].SubItems[1].Text;
                txtHighlighted.Text = str;
            }
            catch (Exception x) { }
        }

        private void frmSTMT_Entry_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnTest.Visible = false;
                this.btnPostAfterTest.Visible = false;

                this.flag_ = @"init";
                LoadJulianDates();
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private void LoadJulianDates() {
            var dates = new JDates { }.getJulianConfiguration();

            if (dates != null) {
                foreach (var d in dates) {
                    ListViewItem L = new ListViewItem(d.Id.ToString());
                    L.SubItems.Add(d.periodFrom);
                    L.SubItems.Add(d.periodTo);
                    L.SubItems.Add(d.julianFrom);
                    L.SubItems.Add(d.julianTo);

                    this.lvjDates.Items.Add(L);
                }
            }
        }

        private void lvjDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtJulianFrom.Text = lvjDates.SelectedItems[0].SubItems[3].Text;
                txtJulianTo.Text = lvjDates.SelectedItems[0].SubItems[4].Text;

                this.txtInterval.Focus();
            }
            catch (Exception x) { }
        }

        private void btnDataStore_Click(object sender, EventArgs e)
        {
            //method is used to push data to the data store and show status in the status bar
            thDtStorage = new Thread(()=>PushToDataStore());
            thDtStorage.Priority = ThreadPriority.Highest;
            thDtStorage.Start();
        }

        private void PushToDataStore() { 
            //method is used to push data to the data store
            try
            {
                if (stmtRecords != null) {
                    var success = 0; var failed = 0;
                    foreach (var item in stmtRecords) {
                        if (item.saveRecord()) { success += 1; DataCount -=1; } 
                        else 
                        { 
                            failed += 1;
                            /** */
                            //write to log file
                            var str = string.Format("RecordID: {0}, ReferenceNo: {1}, Amount: {2}, AmountDirection: {3}, valueDate: {4}, postingDate: {5}",
                                                        item.RECID, item.transReference, item.Amt.ToString(), item.AmtDirection, item.postDate);
                            
                            new Error { message = str }.LogError();
                            MessageBox.Show(str, @"ERROR-TXN DATA", MessageBoxButtons.OK);
                        }
                        lblstatus.Invoke((MethodInvoker)delegate {
                            lblstatus.Text = string.Format("Total Records = {0}, Successful inserts = {1}, Failed inserts = {2}", stmtRecords.Count().ToString(), success.ToString(), failed.ToString());
                        });
                        lblbatchstatus.Invoke((MethodInvoker)delegate {
                            lblbatchstatus.Text = string.Format("Total Records: {0}, Records pushed: {1}, Records left: {2}", DataCount.ToString(), success.ToString(), (stmtRecords.Count() - success).ToString());
                        });
                    }
                }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private void btnLoadDuplicates_Click(object sender, EventArgs e)
        {
            try
            {
                this.duplicate_data = new STMT_Entry() { }.getTxnDuplicates();
                if (duplicate_data != null) {
                    this.lvDetails.Items.Clear();
                    int i = 0;
                    foreach (var d in duplicate_data) {
                        ListViewItem L = new ListViewItem(d.RECID);
                        L.SubItems.Add(d.BATCHSIZE.ToString());

                        this.lvDetails.Items.Add(L);
                        i += 1;
                    }

                    lblstatus.Text = string.Format("Total Duplicate records: {0}", i.ToString());
                }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private void btnRemoveDuplicates_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.duplicate_data != null) {
                    th = new Thread(()=>PurgeDuplicateTxns());
                    th.Priority = ThreadPriority.Highest;
                    th.Start();
                }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private void PurgeDuplicateTxns() {
            try
            {
                int i = 0;
                int k = duplicate_data.Count();
                int success = 0;

                foreach (var d in duplicate_data)
                {
                    if (d.executeTxnPurgingProcess())
                    {
                        success += 1;
                        i += d.BATCHSIZE;
                        lblbatchstatus.Invoke((MethodInvoker)delegate
                        {
                            lblbatchstatus.Text = string.Format("{0} duplicates purged for {1}", (d.BATCHSIZE - 1).ToString(),d.RECID);
                        });
                        lblstatus.Invoke((MethodInvoker)delegate {

                            lblstatus.Text = string.Format("Total Duplicate records: {0}", (k - success).ToString());
                            
                        });
                    }
                }
            }
            catch (Exception x) {
                throw x;
            }
        }

        private void btnFetchAndPush_Click(object sender, EventArgs e)
        {
            //find the mode for a fix number of intervals (100k, 200k)

            try
            {
                if (validateJulianDates()) {
                    th = new Thread(()=>RecordLoaderModule());
                    th.Priority = ThreadPriority.Highest;
                    th.Start();
                }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private void RecordLoaderModule() {
            try
            {
                if (this.flag_ == @"init")
                {
                    DataCount = new STMT_Entry { param1 = txtJulianFrom.Text.Trim(), param2 = txtJulianTo.Text.Trim() }.getCount();
                }

                lblbatchstatus.Invoke((MethodInvoker)delegate
                {
                    lblbatchstatus.Text = string.Format("Total Records: {0}", DataCount.ToString());
                });

                this.MODULO_COUNT = DataCount / int.Parse(txtInterval.Text);
                this.MODULO_REMAINDER = DataCount % int.Parse(txtInterval.Text);

                for (int i = 1; i <= this.MODULO_COUNT; i++) {
                    var obj = new STMT_Entry()
                    {
                        param1 = txtJulianFrom.Text.Trim(),
                        param2 = txtJulianTo.Text.Trim(),
                        BATCHSIZE = int.Parse(txtInterval.Text.Trim())
                    };

                    if (STMT_Entry.RECID_POINTER != null)
                    {
                        obj.param1 = STMT_Entry.RECID_POINTER;
                    }

                    lblstatus.Invoke((MethodInvoker)delegate
                    {
                        lblstatus.Text = @"Waiting for action...";
                    });

                    if (DataCount == 0 && this.flag_ == @"init") { return; }
                    if (DataCount > 0 && this.flag_ == @"continuation") { this.stmtRecords = obj.getSTMTEntryRecords(this.flag_); }
                    if (DataCount > 0 && this.flag_ == @"init") { this.stmtRecords = obj.getSTMTEntryRecords(this.flag_); this.flag_ = @"continuation"; }


                    txtHighlighted.Invoke((MethodInvoker)delegate
                    {
                        txtHighlighted.Text = STMT_Entry.RECID_POINTER;
                    });

                    lblIteration.Invoke((MethodInvoker)delegate {
                        lblIteration.Text = string.Format("Iteration: {0} out of {1} processed", i.ToString(), this.MODULO_COUNT.ToString());
                    });

                    try
                    {
                        if (stmtRecords != null)
                        {
                            var success = 0; var failed = 0;
                            foreach (var item in stmtRecords)
                            {
                                if (item.saveRecord()) { success += 1; DataCount -= 1; }
                                else
                                {
                                    failed += 1;
                                    /** */
                                    //write to log file
                                    var str = string.Format("RecordID: {0}, ReferenceNo: {1}, Amount: {2}, AmountDirection: {3}, valueDate: {4}, postingDate: {5}",
                                                                item.RECID, item.transReference, item.Amt.ToString(), item.AmtDirection, item.postDate);

                                    new Error { message = str }.LogError();
                                    MessageBox.Show(str, @"ERROR-TXN DATA", MessageBoxButtons.OK);
                                }

                                lblstatus.Invoke((MethodInvoker)delegate
                                {
                                    lblstatus.Text = string.Format("Total Records = {0}, Successful inserts = {1}, Failed inserts = {2}", stmtRecords.Count().ToString(), success.ToString(), failed.ToString());
                                });

                                lblbatchstatus.Invoke((MethodInvoker)delegate
                                {
                                    lblbatchstatus.Text = string.Format("Total Records: {0}, Records pushed: {1}, Records left: {2}", DataCount.ToString(), success.ToString(), (DataCount - success).ToString());
                                });
                            }
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message);
                    }
                }

                //handling modulo remainder

            }
            catch (Exception x) { 
            
            }
        }

        private void LoadTestData() {
            try
            {
                //string PATH = @"C:\Users\Blessings\Desktop\REC_TXNs.xlsx";
                string PATH = @"C:\Users\Blessings\Desktop\DRIVERS_NIB_2021.xlsx";
                _data = new DriverTestTakers() { filePath = PATH }.LoadExcelFile();

                if (_data != null) {
                    this.lvDetails.Items.Clear();

                    foreach (var d in _data) {
                        this.lvDetails.Invoke((MethodInvoker)delegate {
                            ListViewItem L = new ListViewItem(d.Id.ToString());
                            L.SubItems.Add(d.staffNumber);
                            L.SubItems.Add(d.staffName);
                            L.SubItems.Add(string.Empty);
                            L.SubItems.Add(string.Empty);
                            L.SubItems.Add(string.Empty);
                            L.SubItems.Add(string.Empty);

                            lvDetails.Items.Add(L);
                        });
                    }
                }
            }
            catch { }
        }

        private void PostTestData() {
            try
            {
                if (this._data != null) {
                    int i = 0;
                    int f = 0;

                    foreach (var d in this._data) {
                        if (d.PostRecord()) { i += 1; } else { f += 1; }
                    }

                    MessageBox.Show("POST DRIVERS DATA", string.Format("Total Records: {0}, Successful inserts: {1}, Failed inserts: {2}", this._data.Count().ToString(), i.ToString(), f.ToString()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thTest = new Thread(()=>LoadTestData());
                thTest.Priority = ThreadPriority.Normal;
                thTest.Start();
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private void btnPostAfterTest_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thPost = new Thread(()=>PostTestData());
                thPost.Priority = ThreadPriority.Normal;
                thPost.Start();
            }
            catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }

       
    }
}
