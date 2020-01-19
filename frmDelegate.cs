using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ADM_Management_System
{
    public partial class frmDelegate : Form
    {
        MySqlConnection conn = DBUtils.GetDBConnection();
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
            txtDivision.Enabled = true;
            cmbDivision_Code.Enabled = true;

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
            txtDivision.Enabled = false;
            cmbDivision_Code.Enabled = false;


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
            STATUS_CODE();
            DIVISION_CODE();
        }
        public void STATUS_CODE()
        {
           
            try
            {
                var sql = "SELECT * FROM Status_Code ORDER BY Status_Code ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                cmbStatusCode.Items.Clear();

                while (dr.Read())
                {
                    cmbStatusCode.Items.Add(dr.GetString("Status_Code"));
                    
                }

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

        void DIVISION_CODE()
        {
            try
            {
                var sql = "SELECT * FROM Division ORDER BY ID ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                cmbDivision_Code.Items.Clear();

                while (dr.Read())
                {
                    cmbDivision_Code.Items.Add(dr.GetString("ID"));

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

        void UPDATE_ADD_DELEGATE()
        {
            var name = txtName.Text;
            var tsc = txtTSC.Text;
            var idnumber = txtIDNumber.Text;
            var phone = txtPhone.Text;
            var school = txtSchool.Text;
            var divison = txtDivision.Text;
            var status = cmbStatusCode.Text;
            try{
               // var sql = $
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        private void CmbStatusCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = $"SELECT * FROM Status_Code WHERE Status_Code='{cmbStatusCode.Text}'";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtStatus.Text = dr.GetString("Status");
                }

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

        private void CmbDivision_Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = $"SELECT * FROM Division WHERE ID='{cmbDivision_Code.Text}'";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtDivision.Text = dr.GetString("DivisionName");
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
    }
}
