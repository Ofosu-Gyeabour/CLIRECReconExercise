namespace iVan
{
    partial class ivanFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvOperation = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblActionStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvOperation);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1110, 483);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lvOperation
            // 
            this.lvOperation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvOperation.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvOperation.FullRowSelect = true;
            this.lvOperation.Location = new System.Drawing.Point(6, 11);
            this.lvOperation.Name = "lvOperation";
            this.lvOperation.Size = new System.Drawing.Size(1098, 466);
            this.lvOperation.TabIndex = 0;
            this.lvOperation.UseCompatibleStateImageBehavior = false;
            this.lvOperation.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 1090;
            // 
            // lblActionStatus
            // 
            this.lblActionStatus.AutoSize = true;
            this.lblActionStatus.ForeColor = System.Drawing.Color.Red;
            this.lblActionStatus.Location = new System.Drawing.Point(15, 498);
            this.lblActionStatus.Name = "lblActionStatus";
            this.lblActionStatus.Size = new System.Drawing.Size(128, 17);
            this.lblActionStatus.TabIndex = 1;
            this.lblActionStatus.Text = "lblActionStatus";
            // 
            // ivanFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 518);
            this.Controls.Add(this.lblActionStatus);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ivanFrm";
            this.Text = "iVan::AcctBalance Reconciliation ETL Tool";
            this.Load += new System.EventHandler(this.ivanFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvOperation;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblActionStatus;
    }
}

