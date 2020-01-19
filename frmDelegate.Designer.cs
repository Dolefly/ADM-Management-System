namespace ADM_Management_System
{
    partial class frmDelegate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.cmbStatusCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSchool = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTSC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.btnAddEdit = new System.Windows.Forms.Button();
            this.cmbDivision_Code = new System.Windows.Forms.ComboBox();
            this.txtDivision = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ADM_Management_System.Properties.Resources.edit;
            this.pictureBox1.Location = new System.Drawing.Point(287, 197);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(15, 34);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(254, 23);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "NAME:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDivision);
            this.groupBox1.Controls.Add(this.cmbDivision_Code);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.cmbStatusCode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSchool);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIDNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTSC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(278, 360);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(92, 323);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(177, 23);
            this.txtStatus.TabIndex = 15;
            // 
            // cmbStatusCode
            // 
            this.cmbStatusCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusCode.Enabled = false;
            this.cmbStatusCode.FormattingEnabled = true;
            this.cmbStatusCode.Location = new System.Drawing.Point(16, 323);
            this.cmbStatusCode.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatusCode.Name = "cmbStatusCode";
            this.cmbStatusCode.Size = new System.Drawing.Size(68, 24);
            this.cmbStatusCode.TabIndex = 14;
            this.cmbStatusCode.SelectedIndexChanged += new System.EventHandler(this.CmbStatusCode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 302);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "STATUS:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 255);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "DIVISION:";
            // 
            // txtSchool
            // 
            this.txtSchool.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSchool.Enabled = false;
            this.txtSchool.Location = new System.Drawing.Point(15, 226);
            this.txtSchool.Margin = new System.Windows.Forms.Padding(4);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(254, 23);
            this.txtSchool.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 207);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "SCHOOL:";
            // 
            // txtPhone
            // 
            this.txtPhone.Enabled = false;
            this.txtPhone.Location = new System.Drawing.Point(15, 178);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(254, 23);
            this.txtPhone.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 159);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "PHONE:";
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.Enabled = false;
            this.txtIDNumber.Location = new System.Drawing.Point(15, 130);
            this.txtIDNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(254, 23);
            this.txtIDNumber.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID NO:";
            // 
            // txtTSC
            // 
            this.txtTSC.Enabled = false;
            this.txtTSC.Location = new System.Drawing.Point(15, 82);
            this.txtTSC.Margin = new System.Windows.Forms.Padding(4);
            this.txtTSC.Name = "txtTSC";
            this.txtTSC.Size = new System.Drawing.Size(254, 23);
            this.txtTSC.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "TSC NO:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Controls.Add(this.btnAddEdit);
            this.groupBox2.Location = new System.Drawing.Point(287, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(163, 190);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(9, 126);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(143, 46);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(9, 73);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(143, 46);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "SAVE";
            this.BtnSave.UseVisualStyleBackColor = true;
            // 
            // btnAddEdit
            // 
            this.btnAddEdit.Location = new System.Drawing.Point(11, 20);
            this.btnAddEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEdit.Name = "btnAddEdit";
            this.btnAddEdit.Size = new System.Drawing.Size(143, 46);
            this.btnAddEdit.TabIndex = 0;
            this.btnAddEdit.Text = "EDIT";
            this.btnAddEdit.UseVisualStyleBackColor = true;
            this.btnAddEdit.Click += new System.EventHandler(this.Button1_Click);
            // 
            // cmbDivision_Code
            // 
            this.cmbDivision_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDivision_Code.Enabled = false;
            this.cmbDivision_Code.FormattingEnabled = true;
            this.cmbDivision_Code.Location = new System.Drawing.Point(19, 276);
            this.cmbDivision_Code.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDivision_Code.Name = "cmbDivision_Code";
            this.cmbDivision_Code.Size = new System.Drawing.Size(68, 24);
            this.cmbDivision_Code.TabIndex = 16;
            this.cmbDivision_Code.SelectedIndexChanged += new System.EventHandler(this.CmbDivision_Code_SelectedIndexChanged);
            // 
            // txtDivision
            // 
            this.txtDivision.Enabled = false;
            this.txtDivision.Location = new System.Drawing.Point(92, 277);
            this.txtDivision.Margin = new System.Windows.Forms.Padding(4);
            this.txtDivision.Name = "txtDivision";
            this.txtDivision.ReadOnly = true;
            this.txtDivision.Size = new System.Drawing.Size(177, 23);
            this.txtDivision.TabIndex = 17;
            // 
            // frmDelegate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 387);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDelegate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Delegate";
            this.Load += new System.EventHandler(this.FrmDelegate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtSchool;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtIDNumber;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtTSC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.Button btnAddEdit;
        public System.Windows.Forms.TextBox txtStatus;
        public System.Windows.Forms.ComboBox cmbStatusCode;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtDivision;
        public System.Windows.Forms.ComboBox cmbDivision_Code;
    }
}