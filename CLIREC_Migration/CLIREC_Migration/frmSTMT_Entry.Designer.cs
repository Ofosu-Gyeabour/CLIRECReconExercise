namespace CLIREC_Migration
{
    partial class frmSTMT_Entry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.btnDataStore = new System.Windows.Forms.Button();
            this.btnFetchAccounts = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJulianTo = new System.Windows.Forms.TextBox();
            this.txtJulianFrom = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lvjDates = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnFetchAndPush = new System.Windows.Forms.Button();
            this.btnLoadDuplicates = new System.Windows.Forms.Button();
            this.btnRemoveDuplicates = new System.Windows.Forms.Button();
            this.lvDetails = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtHighlighted = new System.Windows.Forms.TextBox();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblstatus = new System.Windows.Forms.Label();
            this.lblbatchstatus = new System.Windows.Forms.Label();
            this.lblIteration = new System.Windows.Forms.Label();
            this.btnPostAfterTest = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtInterval);
            this.groupBox5.Controls.Add(this.btnDataStore);
            this.groupBox5.Controls.Add(this.btnFetchAccounts);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtJulianTo);
            this.groupBox5.Controls.Add(this.txtJulianFrom);
            this.groupBox5.Location = new System.Drawing.Point(12, 440);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(222, 160);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Julian Date Range";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Int";
            // 
            // txtInterval
            // 
            this.txtInterval.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterval.ForeColor = System.Drawing.Color.Red;
            this.txtInterval.Location = new System.Drawing.Point(43, 77);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(163, 25);
            this.txtInterval.TabIndex = 8;
            // 
            // btnDataStore
            // 
            this.btnDataStore.Location = new System.Drawing.Point(43, 130);
            this.btnDataStore.Name = "btnDataStore";
            this.btnDataStore.Size = new System.Drawing.Size(163, 23);
            this.btnDataStore.TabIndex = 7;
            this.btnDataStore.Text = "Push to DataStore";
            this.btnDataStore.UseVisualStyleBackColor = true;
            this.btnDataStore.Click += new System.EventHandler(this.btnDataStore_Click);
            // 
            // btnFetchAccounts
            // 
            this.btnFetchAccounts.Location = new System.Drawing.Point(44, 101);
            this.btnFetchAccounts.Name = "btnFetchAccounts";
            this.btnFetchAccounts.Size = new System.Drawing.Size(163, 23);
            this.btnFetchAccounts.TabIndex = 6;
            this.btnFetchAccounts.Text = "Fetch Accounts";
            this.btnFetchAccounts.UseVisualStyleBackColor = true;
            this.btnFetchAccounts.Click += new System.EventHandler(this.btnFetchAccounts_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "From";
            // 
            // txtJulianTo
            // 
            this.txtJulianTo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJulianTo.ForeColor = System.Drawing.Color.Red;
            this.txtJulianTo.Location = new System.Drawing.Point(44, 50);
            this.txtJulianTo.Name = "txtJulianTo";
            this.txtJulianTo.Size = new System.Drawing.Size(163, 25);
            this.txtJulianTo.TabIndex = 2;
            // 
            // txtJulianFrom
            // 
            this.txtJulianFrom.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJulianFrom.ForeColor = System.Drawing.Color.Red;
            this.txtJulianFrom.Location = new System.Drawing.Point(44, 24);
            this.txtJulianFrom.Name = "txtJulianFrom";
            this.txtJulianFrom.Size = new System.Drawing.Size(163, 25);
            this.txtJulianFrom.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lvjDates);
            this.groupBox6.Location = new System.Drawing.Point(6, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(222, 422);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            // 
            // lvjDates
            // 
            this.lvjDates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvjDates.FullRowSelect = true;
            this.lvjDates.GridLines = true;
            this.lvjDates.Location = new System.Drawing.Point(6, 18);
            this.lvjDates.Name = "lvjDates";
            this.lvjDates.Size = new System.Drawing.Size(216, 398);
            this.lvjDates.TabIndex = 0;
            this.lvjDates.UseCompatibleStateImageBehavior = false;
            this.lvjDates.View = System.Windows.Forms.View.Details;
            this.lvjDates.SelectedIndexChanged += new System.EventHandler(this.lvjDates_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "PeriodFrom";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "PeriodTo";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "JulianFrom";
            this.columnHeader8.Width = 300;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "JulianTo";
            this.columnHeader9.Width = 300;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnPostAfterTest);
            this.groupBox7.Controls.Add(this.btnTest);
            this.groupBox7.Controls.Add(this.btnFetchAndPush);
            this.groupBox7.Controls.Add(this.btnLoadDuplicates);
            this.groupBox7.Controls.Add(this.btnRemoveDuplicates);
            this.groupBox7.Controls.Add(this.lvDetails);
            this.groupBox7.Location = new System.Drawing.Point(234, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(903, 579);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(239, 536);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(107, 37);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnFetchAndPush
            // 
            this.btnFetchAndPush.Location = new System.Drawing.Point(377, 536);
            this.btnFetchAndPush.Name = "btnFetchAndPush";
            this.btnFetchAndPush.Size = new System.Drawing.Size(163, 37);
            this.btnFetchAndPush.TabIndex = 9;
            this.btnFetchAndPush.Text = "Fetch and Push";
            this.btnFetchAndPush.UseVisualStyleBackColor = true;
            this.btnFetchAndPush.Click += new System.EventHandler(this.btnFetchAndPush_Click);
            // 
            // btnLoadDuplicates
            // 
            this.btnLoadDuplicates.Location = new System.Drawing.Point(564, 536);
            this.btnLoadDuplicates.Name = "btnLoadDuplicates";
            this.btnLoadDuplicates.Size = new System.Drawing.Size(163, 37);
            this.btnLoadDuplicates.TabIndex = 8;
            this.btnLoadDuplicates.Text = "Load Duplicates";
            this.btnLoadDuplicates.UseVisualStyleBackColor = true;
            this.btnLoadDuplicates.Click += new System.EventHandler(this.btnLoadDuplicates_Click);
            // 
            // btnRemoveDuplicates
            // 
            this.btnRemoveDuplicates.Location = new System.Drawing.Point(733, 536);
            this.btnRemoveDuplicates.Name = "btnRemoveDuplicates";
            this.btnRemoveDuplicates.Size = new System.Drawing.Size(163, 37);
            this.btnRemoveDuplicates.TabIndex = 7;
            this.btnRemoveDuplicates.Text = "Remove Duplicates";
            this.btnRemoveDuplicates.UseVisualStyleBackColor = true;
            this.btnRemoveDuplicates.Click += new System.EventHandler(this.btnRemoveDuplicates_Click);
            // 
            // lvDetails
            // 
            this.lvDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.lvDetails.FullRowSelect = true;
            this.lvDetails.GridLines = true;
            this.lvDetails.Location = new System.Drawing.Point(6, 15);
            this.lvDetails.Name = "lvDetails";
            this.lvDetails.Size = new System.Drawing.Size(891, 515);
            this.lvDetails.TabIndex = 0;
            this.lvDetails.UseCompatibleStateImageBehavior = false;
            this.lvDetails.View = System.Windows.Forms.View.Details;
            this.lvDetails.SelectedIndexChanged += new System.EventHandler(this.lvDetails_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "RECID";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "transReference";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "AcctNo";
            this.columnHeader10.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "PostedDate";
            this.columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "ValueDate";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Narration";
            this.columnHeader13.Width = 150;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Amount";
            this.columnHeader14.Width = 150;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtHighlighted);
            this.groupBox8.Location = new System.Drawing.Point(12, 601);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1131, 138);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            // 
            // txtHighlighted
            // 
            this.txtHighlighted.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighlighted.Location = new System.Drawing.Point(6, 19);
            this.txtHighlighted.Multiline = true;
            this.txtHighlighted.Name = "txtHighlighted";
            this.txtHighlighted.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHighlighted.Size = new System.Drawing.Size(1115, 113);
            this.txtHighlighted.TabIndex = 0;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus.ForeColor = System.Drawing.Color.Red;
            this.lblstatus.Location = new System.Drawing.Point(414, 745);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(176, 17);
            this.lblstatus.TabIndex = 4;
            this.lblstatus.Text = "Waiting for action...";
            // 
            // lblbatchstatus
            // 
            this.lblbatchstatus.AutoSize = true;
            this.lblbatchstatus.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbatchstatus.ForeColor = System.Drawing.Color.Black;
            this.lblbatchstatus.Location = new System.Drawing.Point(16, 745);
            this.lblbatchstatus.Name = "lblbatchstatus";
            this.lblbatchstatus.Size = new System.Drawing.Size(104, 17);
            this.lblbatchstatus.TabIndex = 5;
            this.lblbatchstatus.Text = "Batch status";
            // 
            // lblIteration
            // 
            this.lblIteration.AutoSize = true;
            this.lblIteration.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIteration.Location = new System.Drawing.Point(920, 745);
            this.lblIteration.Name = "lblIteration";
            this.lblIteration.Size = new System.Drawing.Size(80, 17);
            this.lblIteration.TabIndex = 6;
            this.lblIteration.Text = "iteration";
            // 
            // btnPostAfterTest
            // 
            this.btnPostAfterTest.Location = new System.Drawing.Point(58, 536);
            this.btnPostAfterTest.Name = "btnPostAfterTest";
            this.btnPostAfterTest.Size = new System.Drawing.Size(147, 37);
            this.btnPostAfterTest.TabIndex = 11;
            this.btnPostAfterTest.Text = "Post After Test";
            this.btnPostAfterTest.UseVisualStyleBackColor = true;
            this.btnPostAfterTest.Click += new System.EventHandler(this.btnPostAfterTest_Click);
            // 
            // frmSTMT_Entry
            // 
            this.ClientSize = new System.Drawing.Size(1142, 763);
            this.Controls.Add(this.lblIteration);
            this.Controls.Add(this.lblbatchstatus);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSTMT_Entry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STMT ENTRY";
            this.Load += new System.EventHandler(this.frmSTMT_Entry_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFetchAccountsx;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ErrorProvider errx;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtHighlightedx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvDetailsx;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvStatistics;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtErrorFile;
        private System.Windows.Forms.TextBox txtBatchSizex;
        private System.Windows.Forms.ComboBox cboYearx;
        private System.Windows.Forms.OpenFileDialog op;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtJulianFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJulianTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvDetails;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtHighlighted;
        private System.Windows.Forms.ListView lvjDates;
        private System.Windows.Forms.Button btnFetchAccounts;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnDataStore;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lblbatchstatus;
        private System.Windows.Forms.Button btnLoadDuplicates;
        private System.Windows.Forms.Button btnRemoveDuplicates;
        private System.Windows.Forms.Button btnFetchAndPush;
        private System.Windows.Forms.Label lblIteration;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnPostAfterTest;
        
    }
}