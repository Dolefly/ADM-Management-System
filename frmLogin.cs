using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADM_Management_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "")
            {
                if(txtPass.Text != "")
                {
                    frmMain f = new frmMain();
                    f.tspUser.Text = "ADMIN";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter Password", "PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Enter Username", "USERNAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();

        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        public string username { get { return txtUsername.Text; } }
    }
}
