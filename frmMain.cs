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
    public partial class frmMain : Form
    {
        
        public frmMain()
        {
            InitializeComponent();
            
        }
      
        private void Button1_Click(object sender, EventArgs e)
        {
            if (pnMain.Controls.Count < 1)
            {
                frmRegister frm = null;
                if ((frm = (frmRegister)IsFormAlreadyOpen(typeof(frmRegister))) == null)
                {
                    frm = new frmRegister();
                    frm.TopLevel = false;
                    pnMain.Controls.Add(frm);
                    frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;

                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Already Open!", "DELEGATE REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //frm.Close();
                }
            }
            else
            {
                MessageBox.Show("Close open window first!", "REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }
        private void BtnEnabler_Click(object sender, EventArgs e)
        {
           
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DBSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBConnector db = new DBConnector();
            db.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "AMS SYSTEM Version " + Application.ProductVersion;
            frmLogin l = new frmLogin();
            l.ShowDialog();
            tspUser.Text = l.username;
        }

        private void RateSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRate r = new frmRate();
            r.ShowDialog();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            if (pnMain.Controls.Count < 1)
            {
                frmAttendance frm = null;
                if ((frm = (frmAttendance)IsFormAlreadyOpen(typeof(frmAttendance))) == null)
                {
                    frm = new frmAttendance();
                    frm.TopLevel = false;
                    pnMain.Controls.Add(frm);
                    frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;

                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Already Open!", "ATTENDANCE REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //frm.Close();
                }
            }
            else
            {
              
                MessageBox.Show( " Close open window first!", "ATTENDANCE REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            frmExpense x = new frmExpense();
            x.ShowDialog();
        }
    }
}
