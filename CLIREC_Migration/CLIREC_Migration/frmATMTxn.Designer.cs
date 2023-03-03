namespace CLIREC_Migration
{
    partial class frmATMTxn
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
            this.btnTxnData = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTxnData
            // 
            this.btnTxnData.Location = new System.Drawing.Point(29, 34);
            this.btnTxnData.Name = "btnTxnData";
            this.btnTxnData.Size = new System.Drawing.Size(122, 41);
            this.btnTxnData.TabIndex = 0;
            this.btnTxnData.Text = "Upload Txn Data";
            this.btnTxnData.UseVisualStyleBackColor = true;
            this.btnTxnData.Click += new System.EventHandler(this.btnTxnData_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(176, 429);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label1";
            // 
            // frmATMTxn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 522);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnTxnData);
            this.Name = "frmATMTxn";
            this.Text = "ATM Transaction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTxnData;
        private System.Windows.Forms.Label lblStatus;
    }
}