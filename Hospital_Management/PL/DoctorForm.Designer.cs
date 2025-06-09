namespace Hospital_Management.PL
{
    partial class DoctorForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dataGridViewDoctors = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label6 = new Label();
            txtOfficeNumber = new TextBox();
            txtPhone = new TextBox();
            cmbSpecialty = new ComboBox();
            txtDoctorID = new TextBox();
            txtFullName = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDoctors).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Wheat;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(809, 67);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(325, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(158, 50);
            label1.TabIndex = 0;
            label1.Text = "Doctors";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(87, 219);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(88, 28);
            label2.TabIndex = 1;
            label2.Text = "Phone : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(87, 174);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(109, 28);
            label3.TabIndex = 2;
            label3.Text = "Specialty : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(87, 134);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(121, 28);
            label4.TabIndex = 3;
            label4.Text = "Full Name : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(87, 93);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(110, 28);
            label5.TabIndex = 4;
            label5.Text = "DoctorID : ";
            // 
            // dataGridViewDoctors
            // 
            dataGridViewDoctors.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewDoctors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewDoctors.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewDoctors.Location = new Point(87, 305);
            dataGridViewDoctors.Name = "dataGridViewDoctors";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewDoctors.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewDoctors.RowHeadersWidth = 51;
            dataGridViewDoctors.Size = new Size(633, 242);
            dataGridViewDoctors.TabIndex = 9;
            dataGridViewDoctors.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.BackColor = Color.BurlyWood;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button1.Location = new Point(127, 562);
            button1.Name = "button1";
            button1.Size = new Size(124, 56);
            button1.TabIndex = 10;
            button1.Text = "New Doctor";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.BurlyWood;
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button2.Location = new Point(551, 562);
            button2.Name = "button2";
            button2.Size = new Size(124, 56);
            button2.TabIndex = 11;
            button2.Text = "Remove Doctor";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.BurlyWood;
            button3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button3.Location = new Point(415, 562);
            button3.Name = "button3";
            button3.Size = new Size(124, 56);
            button3.TabIndex = 12;
            button3.Text = "Edit Doctor";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.BurlyWood;
            button4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button4.Location = new Point(273, 562);
            button4.Name = "button4";
            button4.Size = new Size(124, 56);
            button4.TabIndex = 13;
            button4.Text = "Add Doctor";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(87, 257);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(83, 28);
            label6.TabIndex = 14;
            label6.Text = "Office : ";
            // 
            // txtOfficeNumber
            // 
            txtOfficeNumber.Font = new Font("Segoe UI", 9F);
            txtOfficeNumber.Location = new Point(204, 258);
            txtOfficeNumber.MaxLength = 4;
            txtOfficeNumber.Name = "txtOfficeNumber";
            txtOfficeNumber.Size = new Size(516, 27);
            txtOfficeNumber.TabIndex = 15;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 9F);
            txtPhone.Location = new Point(204, 220);
            txtPhone.MaxLength = 10;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(516, 27);
            txtPhone.TabIndex = 6;
            // 
            // cmbSpecialty
            // 
            cmbSpecialty.AllowDrop = true;
            cmbSpecialty.Font = new Font("Segoe UI", 9F);
            cmbSpecialty.FormattingEnabled = true;
            cmbSpecialty.Items.AddRange(new object[] { "Cardiology", "Neurology", "Pediatrics", "Orthopedics", "General Medicine", "Dermatology", "Radiology", "Surgery" });
            cmbSpecialty.Location = new Point(204, 178);
            cmbSpecialty.Name = "cmbSpecialty";
            cmbSpecialty.Size = new Size(516, 28);
            cmbSpecialty.TabIndex = 16;
            // 
            // txtDoctorID
            // 
            txtDoctorID.Font = new Font("Segoe UI", 9F);
            txtDoctorID.Location = new Point(204, 94);
            txtDoctorID.Name = "txtDoctorID";
            txtDoctorID.ReadOnly = true;
            txtDoctorID.Size = new Size(516, 27);
            txtDoctorID.TabIndex = 5;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 9F);
            txtFullName.Location = new Point(204, 138);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(516, 27);
            txtFullName.TabIndex = 8;
            // 
            // DoctorForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(809, 630);
            Controls.Add(cmbSpecialty);
            Controls.Add(txtOfficeNumber);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewDoctors);
            Controls.Add(txtFullName);
            Controls.Add(txtPhone);
            Controls.Add(txtDoctorID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Margin = new Padding(4);
            Name = "DoctorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Doctors";
            Load += DoctorForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDoctors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dataGridViewDoctors;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label6;
        private TextBox txtOfficeNumber;
        private TextBox txtPhone;
        private ComboBox cmbSpecialty;
        private TextBox txtDoctorID;
        private TextBox txtFullName;
    }
}