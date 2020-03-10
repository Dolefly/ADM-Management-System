using Renci.SshNet.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADM_Management_System
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
        void GetSettings()
        {
            try
            {
                var regKey = myFunctions.GetRegistrySettings();

                var dbSettings = myFunctions.IsServerConnected();
                lblSettings.Text = "Getting registry settings....";
                if (regKey == "")
                {
                    lblSettings.ForeColor = Color.Red;
                    lblSettings.Text = ("No settings found!");
                    lblDBSettings.Visible = true;
                    btnRefresh.Visible = true;
                }
                else if(dbSettings == true)
                {
                    lblSettings.ForeColor = Color.Green;
                    lblSettings.Text = ("Connected!");
                    this.Close();

                }
                else if (dbSettings == false)
                {
                    lblSettings.ForeColor = Color.Red;
                    lblSettings.Text = "No server found!";
                    lblDBSettings.Visible = true;
                    btnRefresh.Visible = true;
                }
                
            }
            catch(Exception ex)
            {
                lblSettings.ForeColor = Color.Red;
                lblSettings.Text = ("No settings found!");
                lblDBSettings.Visible = true;
                btnRefresh.Visible = true;

            }
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
          //  GetSettings();
            timeLeft = 100;
            timer1.Start();
           // this.Close();
        }

        public int timeLeft { get; set; }

        private void LblDBSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBConnector db = new DBConnector();
            db.ShowDialog();
        }

        private void FrmSplash_KeyDown(object sender, KeyEventArgs e)
        {
            
            }

        private void FrmSplash_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GetSettings();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(timeLeft > 90)
            {
                timeLeft = timeLeft -1;
                progressBar1.Value = 10;
                lblSettings.Text = "Getting registry settings..";
            }
            else if (timeLeft > 70)
            {
                timeLeft = timeLeft - 1;
                progressBar1.Value = 30 ;
                lblSettings.Text = "Saving Registry Settings..";
            }
            else if(timeLeft > 50)
            {
                timeLeft = timeLeft - 1;
                progressBar1.Value = 50;
                lblSettings.Text = "Getting database settings..";
               
            }
            else if (timeLeft > 30)
            {
                timeLeft = timeLeft - 1;
                progressBar1.Value = 70;
                lblSettings.Text = "Testing database settings..";
              
            }
            else if(timeLeft > 10)
            {
                timeLeft = timeLeft - 1;
                progressBar1.Value = 100;
              //  lblSettings.Text = "All settings saved!";
            }
            else
            {
               timer1.Stop();
                GetSettings();
            }
        }
    }
    
}
