using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region added Namespaces

using System.Threading;
using System.Configuration;
using System.Diagnostics;

using Igor.utils;

#endregion

namespace Igor
{
    public partial class IgorFrm : Form
    {
        public IgorFrm()
        {
            InitializeComponent();
        }

        System.Timers.Timer oTimer = null;

        #region Initialization

        private void InitializeSystemTimer()
        {
            try
            {
                //get configuration file
                var configObj = new Config() { }.getConfigObject();

                if (configObj != null) 
                {
                    this.oTimer = new System.Timers.Timer(configObj.interVal);
                    this.oTimer.AutoReset = true;
                    this.oTimer.Enabled = true;
                    this.oTimer.Start();

                    this.oTimer.Elapsed += new System.Timers.ElapsedEventHandler(FILE_MANAGEMENT_MODULE);
                }
                
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
        }

        private void FILE_MANAGEMENT_MODULE(object sender, System.Timers.ElapsedEventArgs e)
        {
            //manages the connection and the entire file management processes and services
            /* check service that connects to the storage..very critical */
            /* check to see if all folders of companies are created */
            /* checks the assignment and revocation of user rights */
            /* checks to validate the format of documents uploaded into storage */
            /*  */
            try
            {
                var folderValidationThread = new Thread(()=>folderValidation());
                folderValidationThread.Name = @"folderValidation";
                folderValidationThread.Priority = ThreadPriority.Highest;
                folderValidationThread.Start();
            }
            catch { }
        }

        #endregion

        #region Processes and Services

        private void folderValidation() { 
            //checks and validate folders

        }

        #endregion

        private void IgorFrm_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitializeSystemTimer();
            }
            catch { }
        }
    }
}
