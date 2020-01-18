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
    public partial class frmDelegate : Form
    {
        public frmDelegate()
        {
            InitializeComponent();
        }

        void ENABLE_EDIT()
        {
            txtIDNumber.Enabled = true;
            txtName.Enabled = true;
            txtPhone.Enabled = true;
            txtSchool.Enabled = true;
            txtTSC.Enabled = false;
            txtStatus.Enabled = true;

            cmbStatusCode.Enabled = true;
            cmbDivision.Enabled = true;

            BtnSave.Enabled = true;
            btnCancel.Enabled = true;

            btnAddEdit.Enabled = false;
            
        }

        void DISABLE_EDIT()
        {
            txtIDNumber.Enabled = false;
            txtName.Enabled = false;
            txtPhone.Enabled = false;
            txtSchool.Enabled = false;
            txtTSC.Enabled = false;
            txtStatus.Enabled = false;

            cmbStatusCode.Enabled = false;
            cmbDivision.Enabled = false;


            BtnSave.Enabled = false;
            btnCancel.Enabled = false;

            btnAddEdit.Enabled = true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (btnAddEdit.Text == "EDIT")
            {
                ENABLE_EDIT();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DISABLE_EDIT();

            btnCancel.Enabled = false;
        }

        private void FrmDelegate_Load(object sender, EventArgs e)
        {

        }
    }
}
