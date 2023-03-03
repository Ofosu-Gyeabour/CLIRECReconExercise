namespace Igor
{
    partial class IgorFrm
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
            this.grp = new System.Windows.Forms.GroupBox();
            this.Lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.Lv);
            this.grp.Location = new System.Drawing.Point(4, 5);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(958, 437);
            this.grp.TabIndex = 0;
            this.grp.TabStop = false;
            // 
            // Lv
            // 
            this.Lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.Lv.FullRowSelect = true;
            this.Lv.Location = new System.Drawing.Point(0, 7);
            this.Lv.Name = "Lv";
            this.Lv.Size = new System.Drawing.Size(958, 423);
            this.Lv.TabIndex = 0;
            this.Lv.UseCompatibleStateImageBehavior = false;
            this.Lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 950;
            // 
            // IgorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 447);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IgorFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Igor::File Management System";
            this.Load += new System.EventHandler(this.IgorFrm_Load);
            this.grp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.ListView Lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

