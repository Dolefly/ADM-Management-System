using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ADM_Management_System
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {


            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            f.btnEnabler.PerformClick();

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
                var sql = "SELECT Register.TSC_No,Register.ID_Number,Register.`Name`,Register.Phone,School.`Name` AS School,(Division.`Name`) AS Division FROM Register INNER JOIN School ON School.Tsc_No = Register.TSC_No AND Register.School_ID = School.ID INNER JOIN Division ON Register.Division_ID = Division.ID ORDER BY Register.TSC_No ASC";
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
        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }
    }
}
