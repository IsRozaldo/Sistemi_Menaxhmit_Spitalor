namespace Hospital_Management
{
    partial class ReceptionistForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            txtPhoneNumber = new TextBox();
            label6 = new Label();
            txtFullName = new TextBox();
            txtPassword = new TextBox();
            txtReceptionistID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dataGridViewReceptionists = new DataGridView();
            btnAddRec = new Button();
            btnEditRec = new Button();
            btnRemoveRec = new Button();
            btnNewRec = new Button();
            chkShowPassword = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReceptionists).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Wheat;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 70);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(264, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(253, 50);
            label1.TabIndex = 1;
            label1.Text = "Receptionists";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(218, 168);
            txtPhoneNumber.MaxLength = 10;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(516, 27);
            txtPhoneNumber.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(63, 171);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(88, 28);
            label6.TabIndex = 24;
            label6.Text = "Phone : ";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(218, 126);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(516, 27);
            txtFullName.TabIndex = 23;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(218, 254);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(359, 27);
            txtPassword.TabIndex = 22;
            // 
            // txtReceptionistID
            // 
            txtReceptionistID.Location = new Point(218, 85);
            txtReceptionistID.Name = "txtReceptionistID";
            txtReceptionistID.ReadOnly = true;
            txtReceptionistID.Size = new Size(516, 27);
            txtReceptionistID.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(63, 84);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(160, 28);
            label5.TabIndex = 20;
            label5.Text = "ReceptionistID : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(63, 126);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(121, 28);
            label4.TabIndex = 19;
            label4.Text = "Full Name : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(63, 212);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(121, 28);
            label3.TabIndex = 18;
            label3.Text = "Username : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(63, 253);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(114, 28);
            label2.TabIndex = 17;
            label2.Text = "Password : ";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(218, 212);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(516, 27);
            txtUsername.TabIndex = 26;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dataGridViewReceptionists
            // 
            dataGridViewReceptionists.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewReceptionists.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewReceptionists.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReceptionists.Location = new Point(63, 302);
            dataGridViewReceptionists.Name = "dataGridViewReceptionists";
            dataGridViewReceptionists.RowHeadersWidth = 51;
            dataGridViewReceptionists.Size = new Size(671, 246);
            dataGridViewReceptionists.TabIndex = 27;
            dataGridViewReceptionists.CellContentClick += dataGridViewReceptionists_CellContentClick;
            // 
            // btnAddRec
            // 
            btnAddRec.BackColor = Color.BurlyWood;
            btnAddRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddRec.Location = new Point(279, 564);
            btnAddRec.Name = "btnAddRec";
            btnAddRec.Size = new Size(124, 56);
            btnAddRec.TabIndex = 31;
            btnAddRec.Text = "Add Receptionist";
            btnAddRec.UseVisualStyleBackColor = false;
            btnAddRec.Click += btnAddRec_Click;
            // 
            // btnEditRec
            // 
            btnEditRec.BackColor = Color.BurlyWood;
            btnEditRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEditRec.Location = new Point(421, 564);
            btnEditRec.Name = "btnEditRec";
            btnEditRec.Size = new Size(124, 56);
            btnEditRec.TabIndex = 30;
            btnEditRec.Text = "Edit Receptionist";
            btnEditRec.UseVisualStyleBackColor = false;
            btnEditRec.Click += btnEditRec_Click;
            // 
            // btnRemoveRec
            // 
            btnRemoveRec.BackColor = Color.BurlyWood;
            btnRemoveRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRemoveRec.Location = new Point(557, 564);
            btnRemoveRec.Name = "btnRemoveRec";
            btnRemoveRec.Size = new Size(124, 56);
            btnRemoveRec.TabIndex = 29;
            btnRemoveRec.Text = "Remove Receptionist";
            btnRemoveRec.UseVisualStyleBackColor = false;
            btnRemoveRec.Click += btnRemoveRec_Click;
            // 
            // btnNewRec
            // 
            btnNewRec.BackColor = Color.BurlyWood;
            btnNewRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNewRec.Location = new Point(133, 564);
            btnNewRec.Name = "btnNewRec";
            btnNewRec.Size = new Size(124, 56);
            btnNewRec.TabIndex = 28;
            btnNewRec.Text = "New Receptionist";
            btnNewRec.UseVisualStyleBackColor = false;
            btnNewRec.Click += btnNewRec_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkShowPassword.Location = new Point(583, 253);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(151, 27);
            chkShowPassword.TabIndex = 32;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // ReceptionistForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(800, 636);
            Controls.Add(chkShowPassword);
            Controls.Add(btnAddRec);
            Controls.Add(btnEditRec);
            Controls.Add(btnRemoveRec);
            Controls.Add(btnNewRec);
            Controls.Add(dataGridViewReceptionists);
            Controls.Add(txtUsername);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label6);
            Controls.Add(txtFullName);
            Controls.Add(txtPassword);
            Controls.Add(txtReceptionistID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "ReceptionistForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receptionist";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReceptionists).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtPhoneNumber;
        private Label label6;
        private TextBox txtFullName;
        private TextBox txtPassword;
        private TextBox txtReceptionistID;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtUsername;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DataGridView dataGridViewReceptionists;
        private Button btnAddRec;
        private Button btnEditRec;
        private Button btnRemoveRec;
        private Button btnNewRec;
        private CheckBox chkShowPassword;
    }
}