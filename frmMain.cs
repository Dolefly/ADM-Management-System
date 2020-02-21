using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
           
        }
        //Code to pass Username to Child form
       // public string Uname { get { return tspUser.Text; } }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "AMS SYSTEM Version " + Application.ProductVersion;
            frmLogin l = new frmLogin();
            l.ShowDialog();
            tspUser.Text = l.username;
            tspUserID.Text = l.userID;
            
        }

        private void RateSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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

        private void Button3_Click(object sender, EventArgs e)
        {
            frmLogin l = new frmLogin();
            l.ShowDialog();
            tspUser.Text = l.username;
            tspUserID.Text = l.userID;
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser ur = new frmUser();
            ur.ShowDialog();
        }

        private void RolesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RolesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var uName = tspUser.Text;
            var rID = 1;

            var uRole = myFunctions.GetRBAC(uName, rID);
            
            if(uRole != "")
            {
                frmRBAC rb = new frmRBAC();
                rb.Text = tspUser.Text;
                rb.ShowDialog();
            }
            else
            {
                MessageBox.Show("You dont have privileges to access this module!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        private void ConnectivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var uName = tspUser.Text;
            var rID = 1;

            var uRole = myFunctions.GetRBAC(uName, rID);

            if (uRole != "")
            {
                DBConnector db = new DBConnector();
                db.ShowDialog();
            }
            else
            {
                MessageBox.Show("You dont have privileges to access this module!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }

        private void RateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var uName = tspUser.Text;
            var rID = 1;

            var uRole = myFunctions.GetRBAC(uName, rID);

            if (uRole != "")
            {
                frmRate rt = new frmRate();
                rt.ShowDialog();
            }
            else
            {
                MessageBox.Show("You dont have privileges to access this module!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var uName = tspUser.Text;
            var rID = 2;

            var uRole = myFunctions.GetRBAC(uName, rID);

            if (uRole != "")
            {
                MessageBox.Show("Reports can be seen");
            }
            else
            {
                MessageBox.Show("You dont have privileges to access this module!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    } 
}
