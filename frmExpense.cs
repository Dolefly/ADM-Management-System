using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
           

            txtDate.Value = DateTime.Now;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnNew.Enabled = false;
            
        }

        void DISABLE_FIELDS()
        {
            txtAmount.Enabled = false;
            txtDate.Enabled =false;
            txtDescription.Enabled = false;
           

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

        void SAVE()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();

            var tDate = txtDate.Text;
           
            var desc = txtDescription.Text;
            var amount = txtAmount.Text;

            try
            {
                var sql = $"INSERT INTO Expense(Date,Narration,Amount) VALUES('{tDate}','{desc}','{amount}')";
                conn.Open();

                var cmd = new MySqlCommand(sql,conn);
                var dr = cmd.ExecuteNonQuery();

                MessageBox.Show("Transaction Saved", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Dispose();
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(txtAmount.Text != "")
            {
                if(txtDescription.Text != "")
                {
                    SAVE();
                    DISABLE_FIELDS();
                }
                else
                {
                    MessageBox.Show("Provide narration first!", "DESCRIPTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("You must enter Amount!", "AMOUNT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
    }
}
