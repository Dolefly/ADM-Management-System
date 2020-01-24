using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public partial class frmRPTregister : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public frmRPTregister()
        {
            InitializeComponent();
        }

        private void FrmRPTregister_Load(object sender, EventArgs e)
        {
           
        }

        void GetReport()
        {

            try
            {

                MySqlCommand cmd;
                MySqlDataAdapter adap;
              //  conn.Open();

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Register.TSC_No,Register.Name, School.Name AS School,Division.DivisionName AS Division FROM School INNER JOIN Register ON School.Tsc_No = Register.TSC_No INNER JOIN Division ON Register.Division_ID = Division.ID ORDER BY Register.TSC_No";

               

                

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
