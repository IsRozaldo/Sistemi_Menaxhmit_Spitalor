namespace Hospital_Management.PL
{
    partial class PatientForm
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
            panel1 = new Panel();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtFullName = new TextBox();
            txtAge = new TextBox();
            txtPhoneNumber = new TextBox();
            txtDescription = new TextBox();
            dataGridViewPatients = new DataGridView();
            btnAddPatient = new Button();
            btnEditPatient = new Button();
            button3 = new Button();
            txtPatientID = new TextBox();
            label2 = new Label();
            btnNewPatient = new Button();
            cmbAssignedDoctor = new ComboBox();
            btnRefresh = new Button();
            cmbGender = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPatients).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Wheat;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 61);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(312, 6);
            label1.Name = "label1";
            label1.Size = new Size(161, 50);
            label1.TabIndex = 0;
            label1.Text = "Patients";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(72, 164);
            label3.Name = "label3";
            label3.Size = new Size(65, 28);
            label3.TabIndex = 2;
            label3.Text = "Age : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(72, 126);
            label4.Name = "label4";
            label4.Size = new Size(121, 28);
            label4.TabIndex = 3;
            label4.Text = "Full Name : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(72, 203);
            label5.Name = "label5";
            label5.Size = new Size(96, 28);
            label5.TabIndex = 4;
            label5.Text = "Gender : ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(72, 240);
            label6.Name = "label6";
            label6.Size = new Size(88, 28);
            label6.TabIndex = 5;
            label6.Text = "Phone : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.Location = new Point(72, 316);
            label7.Name = "label7";
            label7.Size = new Size(132, 28);
            label7.TabIndex = 6;
            label7.Text = "Description : ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label8.Location = new Point(72, 279);
            label8.Name = "label8";
            label8.Size = new Size(139, 28);
            label8.TabIndex = 7;
            label8.Text = "Assigned To : ";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(209, 127);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(510, 27);
            txtFullName.TabIndex = 9;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(209, 164);
            txtAge.MaxLength = 3;
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(510, 27);
            txtAge.TabIndex = 10;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(209, 241);
            txtPhoneNumber.MaxLength = 10;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(510, 27);
            txtPhoneNumber.TabIndex = 12;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(209, 316);
            txtDescription.MaxLength = 150;
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(510, 78);
            txtDescription.TabIndex = 14;
            // 
            // dataGridViewPatients
            // 
            dataGridViewPatients.AllowUserToOrderColumns = true;
            dataGridViewPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPatients.Location = new Point(72, 400);
            dataGridViewPatients.Name = "dataGridViewPatients";
            dataGridViewPatients.RowHeadersWidth = 51;
            dataGridViewPatients.Size = new Size(644, 256);
            dataGridViewPatients.TabIndex = 15;
            dataGridViewPatients.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnAddPatient
            // 
            btnAddPatient.BackColor = Color.BurlyWood;
            btnAddPatient.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddPatient.Location = new Point(322, 671);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Size = new Size(128, 47);
            btnAddPatient.TabIndex = 16;
            btnAddPatient.Text = "Add Patient";
            btnAddPatient.UseVisualStyleBackColor = false;
            btnAddPatient.Click += button1_Click;
            // 
            // btnEditPatient
            // 
            btnEditPatient.BackColor = Color.BurlyWood;
            btnEditPatient.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEditPatient.Location = new Point(456, 671);
            btnEditPatient.Name = "btnEditPatient";
            btnEditPatient.Size = new Size(128, 47);
            btnEditPatient.TabIndex = 17;
            btnEditPatient.Text = "Edit Patient";
            btnEditPatient.UseVisualStyleBackColor = false;
            btnEditPatient.Click += btnEditPatient_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.BurlyWood;
            button3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button3.Location = new Point(590, 671);
            button3.Name = "button3";
            button3.Size = new Size(128, 47);
            button3.TabIndex = 18;
            button3.Text = "Remove Patient";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // txtPatientID
            // 
            txtPatientID.Location = new Point(209, 92);
            txtPatientID.Name = "txtPatientID";
            txtPatientID.ReadOnly = true;
            txtPatientID.Size = new Size(510, 27);
            txtPatientID.TabIndex = 20;
            txtPatientID.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(73, 88);
            label2.Name = "label2";
            label2.Size = new Size(112, 28);
            label2.TabIndex = 19;
            label2.Text = "PatientID : ";
            label2.Visible = false;
            // 
            // btnNewPatient
            // 
            btnNewPatient.BackColor = Color.BurlyWood;
            btnNewPatient.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNewPatient.Location = new Point(188, 671);
            btnNewPatient.Name = "btnNewPatient";
            btnNewPatient.Size = new Size(128, 47);
            btnNewPatient.TabIndex = 21;
            btnNewPatient.Text = "New Patient";
            btnNewPatient.UseVisualStyleBackColor = false;
            btnNewPatient.Click += btnNewPatient_Click;
            // 
            // cmbAssignedDoctor
            // 
            cmbAssignedDoctor.FormattingEnabled = true;
            cmbAssignedDoctor.Location = new Point(209, 279);
            cmbAssignedDoctor.Name = "cmbAssignedDoctor";
            cmbAssignedDoctor.Size = new Size(512, 28);
            cmbAssignedDoctor.TabIndex = 22;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.BurlyWood;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRefresh.Location = new Point(72, 671);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 47);
            btnRefresh.TabIndex = 23;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbGender.Location = new Point(209, 203);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(510, 28);
            cmbGender.TabIndex = 24;
            // 
            // PatientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(800, 730);
            Controls.Add(cmbGender);
            Controls.Add(btnRefresh);
            Controls.Add(cmbAssignedDoctor);
            Controls.Add(btnNewPatient);
            Controls.Add(txtPatientID);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(btnEditPatient);
            Controls.Add(btnAddPatient);
            Controls.Add(dataGridViewPatients);
            Controls.Add(txtDescription);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtAge);
            Controls.Add(txtFullName);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            Name = "PatientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Patient";
            Load += PatientForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtFullName;
        private TextBox txtAge;
        private TextBox txtPhoneNumber;
        private TextBox txtDescription;
        private DataGridView dataGridViewPatients;
        private Button btnAddPatient;
        private Button btnEditPatient;
        private Button button3;
        private TextBox txtPatientID;
        private Label label2;
        private Button btnNewPatient;
        private ComboBox cmbAssignedDoctor;
        private Button btnRefresh;
        private ComboBox cmbGender;
    }
}