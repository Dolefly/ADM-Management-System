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
            else {
                MessageBox.Show("Already Open!","DELEGATE REGISTER",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //frm.Close();
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
        }
    }
}
