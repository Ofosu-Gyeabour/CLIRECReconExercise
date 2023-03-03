namespace CLIREC_Migration
{
    partial class frmCLIREC_Center
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvStatistics = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvDetails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtHighlighted = new System.Windows.Forms.TextBox();
            this.op = new System.Windows.Forms.OpenFileDialog();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFbnkStmtEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.btnDataStore = new System.Windows.Forms.Button();
            this.btnFetchAccounts = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJulianTo = new System.Windows.Forms.TextBox();
            this.txtJulianFrom = new System.Windows.Forms.TextBox();
            this.lblstatus = new System.Windows.Forms.Label();
            this.lblActionStatus = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.mnu.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvStatistics);
            this.groupBox2.Location = new System.Drawing.Point(3, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(357, 510);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lvStatistics
            // 
            this.lvStatistics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvStatistics.FullRowSelect = true;
            this.lvStatistics.GridLines = true;
            this.lvStatistics.Location = new System.Drawing.Point(12, 11);
            this.lvStatistics.Margin = new System.Windows.Forms.Padding(4);
            this.lvStatistics.Name = "lvStatistics";
            this.lvStatistics.Size = new System.Drawing.Size(336, 490);
            this.lvStatistics.TabIndex = 0;
            this.lvStatistics.UseCompatibleStateImageBehavior = false;
            this.lvStatistics.View = System.Windows.Forms.View.Details;
            this.lvStatistics.SelectedIndexChanged += new System.EventHandler(this.lvStatistics_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "@ID";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Period From";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Period To";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Julian From";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Julian To";
            this.columnHeader7.Width = 200;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvDetails);
            this.groupBox3.Location = new System.Drawing.Point(369, 26);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1037, 700);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // lvDetails
            // 
            this.lvDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvDetails.FullRowSelect = true;
            this.lvDetails.GridLines = true;
            this.lvDetails.Location = new System.Drawing.Point(8, 15);
            this.lvDetails.Margin = new System.Windows.Forms.Padding(4);
            this.lvDetails.Name = "lvDetails";
            this.lvDetails.Size = new System.Drawing.Size(1014, 677);
            this.lvDetails.TabIndex = 0;
            this.lvDetails.UseCompatibleStateImageBehavior = false;
            this.lvDetails.View = System.Windows.Forms.View.Details;
            this.lvDetails.SelectedIndexChanged += new System.EventHandler(this.lvDetails_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RECID";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "XMLRECORD";
            this.columnHeader2.Width = 740;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtHighlighted);
            this.groupBox4.Location = new System.Drawing.Point(8, 725);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1398, 95);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // txtHighlighted
            // 
            this.txtHighlighted.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighlighted.Location = new System.Drawing.Point(8, 12);
            this.txtHighlighted.Margin = new System.Windows.Forms.Padding(4);
            this.txtHighlighted.Multiline = true;
            this.txtHighlighted.Name = "txtHighlighted";
            this.txtHighlighted.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHighlighted.Size = new System.Drawing.Size(1375, 72);
            this.txtHighlighted.TabIndex = 0;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationsToolStripMenuItem});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnu.Size = new System.Drawing.Size(1400, 28);
            this.mnu.TabIndex = 4;
            this.mnu.Text = "menuStrip1";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFbnkStmtEntry,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.operationsToolStripMenuItem.Text = "&Operations";
            // 
            // mnuFbnkStmtEntry
            // 
            this.mnuFbnkStmtEntry.Name = "mnuFbnkStmtEntry";
            this.mnuFbnkStmtEntry.Size = new System.Drawing.Size(207, 24);
            this.mnuFbnkStmtEntry.Text = "FBNK_STMT_ENTRY";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(204, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(207, 24);
            this.mnuExit.Text = "E&XIT";
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
            this.groupBox5.Location = new System.Drawing.Point(12, 542);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(348, 176);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Julian Date Range";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Int";
            // 
            // txtInterval
            // 
            this.txtInterval.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterval.ForeColor = System.Drawing.Color.Red;
            this.txtInterval.Location = new System.Drawing.Point(71, 77);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(260, 25);
            this.txtInterval.TabIndex = 8;
            // 
            // btnDataStore
            // 
            this.btnDataStore.Location = new System.Drawing.Point(71, 133);
            this.btnDataStore.Name = "btnDataStore";
            this.btnDataStore.Size = new System.Drawing.Size(260, 23);
            this.btnDataStore.TabIndex = 7;
            this.btnDataStore.Text = "Push to DataStore";
            this.btnDataStore.UseVisualStyleBackColor = true;
            this.btnDataStore.Click += new System.EventHandler(this.btnDataStore_Click);
            // 
            // btnFetchAccounts
            // 
            this.btnFetchAccounts.Location = new System.Drawing.Point(71, 108);
            this.btnFetchAccounts.Name = "btnFetchAccounts";
            this.btnFetchAccounts.Size = new System.Drawing.Size(260, 23);
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
            this.label6.Size = new System.Drawing.Size(25, 17);
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
            this.txtJulianTo.Location = new System.Drawing.Point(71, 50);
            this.txtJulianTo.Name = "txtJulianTo";
            this.txtJulianTo.Size = new System.Drawing.Size(260, 25);
            this.txtJulianTo.TabIndex = 2;
            // 
            // txtJulianFrom
            // 
            this.txtJulianFrom.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJulianFrom.ForeColor = System.Drawing.Color.Red;
            this.txtJulianFrom.Location = new System.Drawing.Point(71, 24);
            this.txtJulianFrom.Name = "txtJulianFrom";
            this.txtJulianFrom.Size = new System.Drawing.Size(260, 25);
            this.txtJulianFrom.TabIndex = 1;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(13, 824);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(31, 17);
            this.lblstatus.TabIndex = 6;
            this.lblstatus.Text = "test";
            // 
            // lblActionStatus
            // 
            this.lblActionStatus.AutoSize = true;
            this.lblActionStatus.ForeColor = System.Drawing.Color.Red;
            this.lblActionStatus.Location = new System.Drawing.Point(726, 824);
            this.lblActionStatus.Name = "lblActionStatus";
            this.lblActionStatus.Size = new System.Drawing.Size(126, 17);
            this.lblActionStatus.TabIndex = 7;
            this.lblActionStatus.Text = "waiting for action...";
            // 
            // frmCLIREC_Center
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 843);
            this.Controls.Add(this.lblActionStatus);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.mnu);
            this.MainMenuStrip = this.mnu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCLIREC_Center";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLIREC Data Migration Center";
            this.Load += new System.EventHandler(this.frmCLIREC_Center_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvStatistics;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvDetails;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.OpenFileDialog op;
        private System.Windows.Forms.TextBox txtHighlighted;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFbnkStmtEntry;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button btnDataStore;
        private System.Windows.Forms.Button btnFetchAccounts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJulianTo;
        private System.Windows.Forms.TextBox txtJulianFrom;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Label lblActionStatus;
    }
}

