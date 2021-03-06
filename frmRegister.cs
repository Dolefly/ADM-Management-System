﻿using MySql.Data.MySqlClient;
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
            GetDivisions();
        }
        void GetSearch()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                var tsc = txtFind.Text;
                var sql = $"SELECT Register.TSC_No,Register.ID_Number,Register.`Name`,Register.Phone,School.`Name` AS School,Division.DivisionName AS Division,Status_Code.`Status` FROM Register INNER JOIN School ON School.Tsc_No = Register.TSC_No INNER JOIN Division ON Register.Division_ID = Division.ID INNER JOIN Status_Code ON Register.`Status` = Status_Code.Status_Code WHERE Register.TSC_No='{tsc}'";
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

                //var sql2 = $"SELECT COUNT(*) AS Total FROM Register WHERE Register.Division_ID='{divID}'";
                //var cmd2 = new MySqlCommand(sql2, conn);
                //var dr2 = cmd2.ExecuteReader();

                //while (dr2.Read())
                //{
                //    this.Text = ("Total: " + dr2.GetString("Total"));
                //}
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
       public void MASTER_REGISTER()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                var sql = "SELECT Register.TSC_No,Register.ID_Number,Register.`Name`,Register.Phone,School.`Name` AS School,Division.DivisionName AS Division,Status_Code.`Status` FROM Register INNER JOIN School ON School.Tsc_No = Register.TSC_No INNER JOIN Division ON Register.Division_ID = Division.ID INNER JOIN Status_Code ON Register.`Status` = Status_Code.Status_Code ORDER BY Register.TSC_No ASC;";
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
                    this.Text = ("Total: " + dr2.GetString("Total"));
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
        public void FilterByDivision()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                var divID = lblDivisionID.Text;
                var sql = $"SELECT Register.TSC_No,Register.ID_Number,Register.`Name`,Register.Phone,School.`Name` AS School,Division.DivisionName AS Division,Status_Code.`Status` FROM Register INNER JOIN School ON School.Tsc_No = Register.TSC_No INNER JOIN Division ON Register.Division_ID = Division.ID INNER JOIN Status_Code ON Register.`Status` = Status_Code.Status_Code WHERE Register.Division_ID='{divID}' ORDER BY Register.TSC_No ASC";
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

                var sql2 = $"SELECT COUNT(*) AS Total FROM Register WHERE Register.Division_ID='{divID}'";
                var cmd2 = new MySqlCommand(sql2, conn);
                var dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    this.Text = ("Total: " + dr2.GetString("Total"));
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
            var tsc = lvDelegates.SelectedItems[0].Text;
            var dName = myFunctions.GetDelegateName(tsc);
            try
            {
               
                var sql = $"DELETE FROM Register WHERE TSC_No='{tsc}'";
               
                conn.Open();
                var cmd = new MySqlCommand(sql,conn);

                var dr = cmd.ExecuteNonQuery();

                MessageBox.Show(dName + " removed successfuly");
                MASTER_REGISTER();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sorry, "+ dName + " cannot be removed because the Delegate has been marked as present!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                var dName = myFunctions.GetDelegateName(TSC);
                DialogResult rs = MessageBox.Show("Are you sure you want to remove " + dName + " from Delegate Register?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
        public void EDIT_DELEGATE()
        {
            try
            {
                var tsc = lvDelegates.SelectedItems[0].Text;
                var sql = $"SELECT Register.TSC_No,Register.ID_Number,Register.`Name`,Register.Phone,School.`Name` AS School,Status_Code.`Status`,(Division.DivisionName) AS Division FROM Register INNER JOIN Division ON Register.Division_ID = Division.ID INNER JOIN School ON School.Tsc_No = Register.TSC_No INNER JOIN Status_Code ON Register.`Status` = Status_Code.Status_Code WHERE Register.TSC_No = '{tsc}' ";
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
                    d.txtDivision.Text = dr.GetString("Division");
                    d.txtStatus.Text = dr.GetString("Status");
                   // d.cmbStatusCode.Text = dr.GetString("Code");

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

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            
            if (chkDivision1.Checked == true)
            {
                if (cmbDivision.Text == "")
                {
                    MessageBox.Show("Select Division to Apply this filter!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if( cmbDivision.Text != "")
                {
                    FilterByDivision();
                }
               
            }
            else if(chkDivision1.Checked == false)
            {
                MASTER_REGISTER();
            }
           
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmDelegate d = new frmDelegate();
            d.btnAddEdit.Text = "NEW";
            d.ShowDialog();
        }

        private void TxtFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // frmRPTregister rt = new frmRPTregister();
            //rt.ShowDialog();
            if (chkDivision1.Checked == true)
            {
                if (cmbDivision.Text != "")
                {
                    FilterByDivisionRPT fd = new FilterByDivisionRPT();
                    fd.Text = cmbDivision.Text;
                    fd.lblDivisionID.Text = lblDivisionID.Text;
                    fd.ShowDialog();
                }
                else if(cmbDivision.Text == "")
                {
                    MessageBox.Show("Select Division to generate report!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(chkDivision1.Checked == false)
            {
                RegisterRPT rt = new RegisterRPT();
                rt.ShowDialog();
            }

           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDivision1.Checked == true)
            {
                cmbDivision.Enabled = true;
            }
            else if (chkDivision1.Checked == false)
            {
                cmbDivision.Enabled = false;
            }
        }
        void GetDivisions()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                var sql = "SELECT * FROM Division ORDER BY DivisionName ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                cmbDivision.Items.Clear();

                while (dr.Read())
                {
                    cmbDivision.Items.Add(dr.GetString("DivisionName"));
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

        void GetDivisionID()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                var DivName = cmbDivision.SelectedItem.ToString();
                var sql = $"SELECT * FROM Division WHERE DivisionName='{DivName}'";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

               // cmbDivision.Items.Clear();

                while (dr.Read())
                {
                    lblDivisionID.Text = dr.GetString("ID");
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
        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDivisionID();
        }

        //private void chkDivision_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkDivision.Checked == true)
        //    {
        //        cmbDivision.Enabled = true;
        //    }
        //    else if (chkDivision.Checked == false)
        //    {
        //        cmbDivision.Enabled = false;
        //    }
        //}

        private void lblDivisionID_Click(object sender, EventArgs e)
        {

        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            GetSearch();
        }
    }
}
