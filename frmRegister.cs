using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ADM_Management_System
{
    public partial class frmRegister : Form
    {
        MySqlConnection conn = DBUtils.GetDBConnection();
        public frmRegister()
        {


            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public static implicit operator frmRegister(bool v)
        {
            throw new NotImplementedException();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            MASTER_REGISTER();
        }
        void MASTER_REGISTER()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                var sql = "SELECT Register.TSC_No,Register.ID_Number,Register.`Name`,Register.Phone,School.`Name` AS School,(Division.`Name`) AS Division,(Status_Code.Status) AS Status FROM Register INNER JOIN School ON School.Tsc_No = Register.TSC_No AND Register.School_ID = School.ID INNER JOIN Division ON Register.Division_ID = Division.ID INNER JOIN Status_Code ON Register.`Status` = Status_Code.Status_Code ORDER BY Register.TSC_No ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();
                lvDelegates.Items.Clear();
                while (dr.Read())
                {
                    var ls = lvDelegates.Items.Add(dr.GetString("TSC_No"));
                    ls.SubItems.Add(dr.GetString("ID_Number"));
                    ls.SubItems.Add(dr.GetString("Name"));
                    ls.SubItems.Add(dr.GetString("Phone"));
                    ls.SubItems.Add(dr.GetString("School"));
                    ls.SubItems.Add(dr.GetString("Division"));
                    ls.SubItems.Add(dr.GetString("Status"));

                }
                dr.Dispose();

                var sql2 = "SELECT COUNT(*) AS Total FROM Register";
                var cmd2 = new MySqlCommand(sql2, conn);
                var dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    this.Text = ("Total Delegates:" + dr2.GetString("Total"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        void DELETE()
        {
            try
            {
                var tsc = lvDelegates.SelectedItems[0].Text;
                var sql = $"DELETE FROM Register WHERE TSC_No='{tsc}'";
                conn.Open();
                var cmd = new MySqlCommand(sql,conn);

                var dr = cmd.ExecuteNonQuery();

                MessageBox.Show(tsc + " removed successfuly");
                MASTER_REGISTER();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
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

        private void LvDelegates_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            btnRemove.Enabled = true;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lvDelegates.SelectedItems.Count == 0)
            {

                return;
            }
            else
            {
                var TSC = lvDelegates.SelectedItems[0].Text;
                DialogResult rs = MessageBox.Show("Are you sure you want to remove TSC Number:" + TSC + " from Delegate Register?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (rs == DialogResult.Yes)
                {
                    DELETE();
                   // MessageBox.Show(TSC + " removed succesfuly!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rs == DialogResult.No)
                {

                }
            }
        }

        private void TxtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LvDelegates_DoubleClick(object sender, EventArgs e)
        {
            EDIT_DELEGATE();
        }
        void EDIT_DELEGATE()
        {
            try
            {
                var tsc = lvDelegates.SelectedItems[0].Text;
                var sql = $"SELECT Register.TSC_No,Register.ID_Number,Register.`Name`,Register.Phone,School.`Name` AS School,(Division.`Name`) AS Division,Status_Code.Status FROM Register INNER JOIN School ON School.Tsc_No = Register.TSC_No AND Register.School_ID = School.ID INNER JOIN Division ON Register.Division_ID = Division.ID INNER JOIN Status_Code ON Register.`Status` = Status_Code.Status_Code WHERE Register.TSC_No ='{tsc}' ";
                conn.Open();
                var cmd = new MySqlCommand(sql,conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    frmDelegate d = new frmDelegate();

                    d.txtName.Text = dr.GetString("Name");
                    d.Text = dr.GetString("Name");
                    d.txtTSC.Text = dr.GetString("TSC_No");
                    d.txtIDNumber.Text = dr.GetString("ID_Number");
                    d.txtPhone.Text = dr.GetString("Phone");
                    d.txtSchool.Text = dr.GetString("School");
                    d.cmbDivision.Text = dr.GetString("Division");
                    d.txtStatus.Text = dr.GetString("Status");

                    d.ShowDialog();
                }
                dr.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
