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
    public partial class frmExpense : Form
    {
        public frmExpense()
        {
            InitializeComponent();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void FrmExpense_Load(object sender, EventArgs e)
        {
            txtDate.Format = DateTimePickerFormat.Custom;
            txtDate.CustomFormat = "yyyy-MM-dd";
        }
        void ENABLE_FIELDS()
        {
            txtAmount.Enabled = true;
            txtDate.Enabled = true;
            txtDescription.Enabled = true;
            txtTransName.Enabled = true;

            txtDate.Value = DateTime.Now;

            btnCancel.Enabled = true;
            btnNew.Enabled = false;
            
        }

        void DISABLE_FIELDS()
        {
            txtAmount.Enabled = false;
            txtDate.Enabled =false;
            txtDescription.Enabled = false;
            txtTransName.Enabled = false;

            txtDate.Value = DateTime.Now;

            btnSave.Enabled = false;
            btnNew.Enabled = true; ;
            btnCancel.Enabled = false;
        }
        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ENABLE_FIELDS();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DISABLE_FIELDS();
        }
    }
}
