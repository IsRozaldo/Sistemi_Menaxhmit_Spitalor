namespace Hospital_Management
{
    partial class Main
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
            label3 = new Label();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            button7 = new Button();
            button5 = new Button();
            btnAppointment = new Button();
            btnReceptionists = new Button();
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.YellowGreen;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1277, 63);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.RoyalBlue;
            label3.Location = new Point(134, 6);
            label3.Name = "label3";
            label3.Size = new Size(119, 54);
            label3.TabIndex = 2;
            label3.Text = "iCare";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = Properties.Resources.heartlogo;
            pictureBox2.Location = new Point(66, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(62, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(311, 9);
            label1.Name = "label1";
            label1.Size = new Size(844, 46);
            label1.TabIndex = 0;
            label1.Text = "The dashboard of the Hospital Management System";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MediumSeaGreen;
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(btnAppointment);
            panel2.Controls.Add(btnReceptionists);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 63);
            panel2.Name = "panel2";
            panel2.Size = new Size(311, 612);
            panel2.TabIndex = 1;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button7.Location = new Point(12, 455);
            button7.Name = "button7";
            button7.Size = new Size(285, 64);
            button7.TabIndex = 7;
            button7.Text = "Medical Record";
            button7.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button5.Location = new Point(12, 375);
            button5.Name = "button5";
            button5.Size = new Size(285, 64);
            button5.TabIndex = 5;
            button5.Text = "Bill";
            button5.UseVisualStyleBackColor = true;
            // 
            // btnAppointment
            // 
            btnAppointment.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAppointment.Location = new Point(12, 297);
            btnAppointment.Name = "btnAppointment";
            btnAppointment.Size = new Size(285, 64);
            btnAppointment.TabIndex = 4;
            btnAppointment.Text = "Appointment";
            btnAppointment.UseVisualStyleBackColor = true;
            btnAppointment.Click += btnAppointment_Click;
            // 
            // btnReceptionists
            // 
            btnReceptionists.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnReceptionists.Location = new Point(12, 219);
            btnReceptionists.Name = "btnReceptionists";
            btnReceptionists.Size = new Size(285, 64);
            btnReceptionists.TabIndex = 3;
            btnReceptionists.Text = "Receptionist";
            btnReceptionists.UseVisualStyleBackColor = true;
            btnReceptionists.Click += btnReceptionists_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button2.Location = new Point(12, 141);
            button2.Name = "button2";
            button2.Size = new Size(285, 64);
            button2.TabIndex = 2;
            button2.Text = "Doctor";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button1.Location = new Point(12, 63);
            button1.Name = "button1";
            button1.Size = new Size(285, 64);
            button1.TabIndex = 1;
            button1.Text = "Patient";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Azure;
            label2.Location = new Point(33, 13);
            label2.Name = "label2";
            label2.Size = new Size(241, 31);
            label2.TabIndex = 0;
            label2.Text = "iCare Hospital Center";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.dashboardimg;
            pictureBox1.Location = new Point(311, 63);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(966, 612);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 675);
            Controls.Add(pictureBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button5;
        private Button btnAppointment;
        private Button btnReceptionists;
        private Button button2;
        private PictureBox pictureBox2;
        private Label label3;
        private Button button7;
    }
}