namespace Hospital_Management.PL
{
    partial class AppointmentForm
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
            txtAge = new TextBox();
            label6 = new Label();
            txtGender = new TextBox();
            txtAppointmentID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label7 = new Label();
            label2 = new Label();
            cmbSelectPatient = new ComboBox();
            cmbCreatedBy = new ComboBox();
            dataGridViewAppointments = new DataGridView();
            btnAddRec = new Button();
            btnEditRec = new Button();
            btnRemoveRec = new Button();
            btnNewRec = new Button();
            label8 = new Label();
            dateTimePickerScheduled = new DateTimePicker();
            cmbAssignedTo = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).BeginInit();
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
            label1.Location = new Point(188, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(422, 50);
            label1.TabIndex = 2;
            label1.Text = "Create an appointment";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(218, 214);
            txtAge.Name = "txtAge";
            txtAge.ReadOnly = true;
            txtAge.Size = new Size(516, 27);
            txtAge.TabIndex = 37;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(51, 169);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(152, 28);
            label6.TabIndex = 35;
            label6.Text = "Appointed To : ";
            // 
            // txtGender
            // 
            txtGender.Location = new Point(218, 256);
            txtGender.Name = "txtGender";
            txtGender.ReadOnly = true;
            txtGender.Size = new Size(516, 27);
            txtGender.TabIndex = 33;
            // 
            // txtAppointmentID
            // 
            txtAppointmentID.Location = new Point(218, 87);
            txtAppointmentID.Name = "txtAppointmentID";
            txtAppointmentID.ReadOnly = true;
            txtAppointmentID.Size = new Size(516, 27);
            txtAppointmentID.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(51, 86);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(170, 28);
            label5.TabIndex = 31;
            label5.Text = "AppointmentID : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(51, 127);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(152, 28);
            label4.TabIndex = 30;
            label4.Text = "Select Patient : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(51, 213);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(65, 28);
            label3.TabIndex = 29;
            label3.Text = "Age : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.Location = new Point(51, 255);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(96, 28);
            label7.TabIndex = 28;
            label7.Text = "Gender : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(51, 296);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(127, 28);
            label2.TabIndex = 38;
            label2.Text = "Created By : ";
            // 
            // cmbSelectPatient
            // 
            cmbSelectPatient.FormattingEnabled = true;
            cmbSelectPatient.Location = new Point(218, 127);
            cmbSelectPatient.Name = "cmbSelectPatient";
            cmbSelectPatient.Size = new Size(516, 28);
            cmbSelectPatient.TabIndex = 39;
            cmbSelectPatient.SelectedIndexChanged += cmbSelectPatient_SelectedIndexChanged;
            // 
            // cmbCreatedBy
            // 
            cmbCreatedBy.FormattingEnabled = true;
            cmbCreatedBy.Location = new Point(218, 296);
            cmbCreatedBy.Name = "cmbCreatedBy";
            cmbCreatedBy.Size = new Size(516, 28);
            cmbCreatedBy.TabIndex = 40;
            // 
            // dataGridViewAppointments
            // 
            dataGridViewAppointments.AllowUserToOrderColumns = true;
            dataGridViewAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAppointments.Location = new Point(55, 379);
            dataGridViewAppointments.Name = "dataGridViewAppointments";
            dataGridViewAppointments.RowHeadersWidth = 51;
            dataGridViewAppointments.Size = new Size(679, 253);
            dataGridViewAppointments.TabIndex = 41;
            // 
            // btnAddRec
            // 
            btnAddRec.BackColor = Color.BurlyWood;
            btnAddRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddRec.Location = new Point(259, 647);
            btnAddRec.Name = "btnAddRec";
            btnAddRec.Size = new Size(124, 56);
            btnAddRec.TabIndex = 45;
            btnAddRec.Text = "Add Appointment";
            btnAddRec.UseVisualStyleBackColor = false;
            btnAddRec.Click += btnAddRec_Click;
            // 
            // btnEditRec
            // 
            btnEditRec.BackColor = Color.BurlyWood;
            btnEditRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEditRec.Location = new Point(401, 647);
            btnEditRec.Name = "btnEditRec";
            btnEditRec.Size = new Size(124, 56);
            btnEditRec.TabIndex = 44;
            btnEditRec.Text = "Edit Appointment";
            btnEditRec.UseVisualStyleBackColor = false;
            btnEditRec.Click += btnEditRec_Click;
            // 
            // btnRemoveRec
            // 
            btnRemoveRec.BackColor = Color.BurlyWood;
            btnRemoveRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRemoveRec.Location = new Point(545, 647);
            btnRemoveRec.Name = "btnRemoveRec";
            btnRemoveRec.Size = new Size(124, 56);
            btnRemoveRec.TabIndex = 43;
            btnRemoveRec.Text = "Remove Appointment";
            btnRemoveRec.UseVisualStyleBackColor = false;
            btnRemoveRec.Click += btnRemoveRec_Click;
            // 
            // btnNewRec
            // 
            btnNewRec.BackColor = Color.BurlyWood;
            btnNewRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNewRec.Location = new Point(113, 647);
            btnNewRec.Name = "btnNewRec";
            btnNewRec.Size = new Size(124, 56);
            btnNewRec.TabIndex = 42;
            btnNewRec.Text = "New Appointment";
            btnNewRec.UseVisualStyleBackColor = false;
            btnNewRec.Click += btnNewRec_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label8.Location = new Point(51, 336);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(167, 28);
            label8.TabIndex = 47;
            label8.Text = "AppointedDate : ";
            // 
            // dateTimePickerScheduled
            // 
            dateTimePickerScheduled.Location = new Point(218, 337);
            dateTimePickerScheduled.Name = "dateTimePickerScheduled";
            dateTimePickerScheduled.Size = new Size(262, 27);
            dateTimePickerScheduled.TabIndex = 48;
            // 
            // cmbAssignedTo
            // 
            cmbAssignedTo.Enabled = false;
            cmbAssignedTo.FormattingEnabled = true;
            cmbAssignedTo.Location = new Point(218, 171);
            cmbAssignedTo.Name = "cmbAssignedTo";
            cmbAssignedTo.Size = new Size(516, 28);
            cmbAssignedTo.TabIndex = 49;
            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(800, 716);
            Controls.Add(cmbAssignedTo);
            Controls.Add(dateTimePickerScheduled);
            Controls.Add(label8);
            Controls.Add(btnAddRec);
            Controls.Add(btnEditRec);
            Controls.Add(btnRemoveRec);
            Controls.Add(btnNewRec);
            Controls.Add(dataGridViewAppointments);
            Controls.Add(cmbCreatedBy);
            Controls.Add(cmbSelectPatient);
            Controls.Add(label2);
            Controls.Add(txtAge);
            Controls.Add(label6);
            Controls.Add(txtGender);
            Controls.Add(txtAppointmentID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(panel1);
            Name = "AppointmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Appointment";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtAge;
        private Label label6;
        private TextBox txtGender;
        private TextBox txtAppointmentID;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label7;
        private Label label2;
        private ComboBox cmbSelectPatient;
        private ComboBox cmbCreatedBy;
        private DataGridView dataGridViewAppointments;
        private Button btnAddRec;
        private Button btnEditRec;
        private Button btnRemoveRec;
        private Button btnNewRec;
        private Label label8;
        private DateTimePicker dateTimePickerScheduled;
        private ComboBox cmbAssignedTo;
    }
}