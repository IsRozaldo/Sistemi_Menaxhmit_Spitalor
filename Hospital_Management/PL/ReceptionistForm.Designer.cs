namespace Hospital_Management.PL
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            txtPhoneNumber = new TextBox();
            label6 = new Label();
            txtFullName = new TextBox();
            txtReceptionistID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            dataGridViewReceptionists = new DataGridView();
            btnAddRec = new Button();
            btnEditRec = new Button();
            btnRemoveRec = new Button();
            btnNewRec = new Button();
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
            // txtReceptionistID
            // 
            txtReceptionistID.Location = new Point(218, 85);
            txtReceptionistID.Name = "txtReceptionistID";
            txtReceptionistID.ReadOnly = true;
            txtReceptionistID.Size = new Size(516, 27);
            txtReceptionistID.TabIndex = 21;
            txtReceptionistID.Visible = false;
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
            label5.Visible = false;
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
            // dataGridViewReceptionists
            // 
            dataGridViewReceptionists.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewReceptionists.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewReceptionists.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReceptionists.Location = new Point(63, 220);
            dataGridViewReceptionists.Name = "dataGridViewReceptionists";
            dataGridViewReceptionists.RowHeadersWidth = 51;
            dataGridViewReceptionists.Size = new Size(671, 320);
            dataGridViewReceptionists.TabIndex = 27;
            dataGridViewReceptionists.CellClick += dataGridViewReceptionists_CellContentClick;
            // 
            // btnAddRec
            // 
            btnAddRec.BackColor = Color.BurlyWood;
            btnAddRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddRec.Location = new Point(274, 555);
            btnAddRec.Name = "btnAddRec";
            btnAddRec.Size = new Size(124, 56);
            btnAddRec.TabIndex = 28;
            btnAddRec.Text = "Add Receptionist";
            btnAddRec.UseVisualStyleBackColor = false;
            btnAddRec.Click += btnAddRec_Click;
            // 
            // btnEditRec
            // 
            btnEditRec.BackColor = Color.BurlyWood;
            btnEditRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEditRec.Location = new Point(404, 555);
            btnEditRec.Name = "btnEditRec";
            btnEditRec.Size = new Size(124, 56);
            btnEditRec.TabIndex = 29;
            btnEditRec.Text = "Edit Receptionist";
            btnEditRec.UseVisualStyleBackColor = false;
            btnEditRec.Click += btnEditRec_Click;
            // 
            // btnRemoveRec
            // 
            btnRemoveRec.BackColor = Color.BurlyWood;
            btnRemoveRec.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRemoveRec.Location = new Point(534, 555);
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
            btnNewRec.Location = new Point(144, 555);
            btnNewRec.Name = "btnNewRec";
            btnNewRec.Size = new Size(124, 56);
            btnNewRec.TabIndex = 28;
            btnNewRec.Text = "New Receptionist";
            btnNewRec.UseVisualStyleBackColor = false;
            btnNewRec.Click += btnNewRec_Click;
            // 
            // ReceptionistForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(800, 625);
            Controls.Add(btnAddRec);
            Controls.Add(btnEditRec);
            Controls.Add(btnRemoveRec);
            Controls.Add(btnNewRec);
            Controls.Add(dataGridViewReceptionists);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label6);
            Controls.Add(txtFullName);
            Controls.Add(txtReceptionistID);
            Controls.Add(label5);
            Controls.Add(label4);
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
        private TextBox txtReceptionistID;
        private Label label5;
        private Label label4;
        private DataGridView dataGridViewReceptionists;
        private Button btnAddRec;
        private Button btnEditRec;
        private Button btnRemoveRec;
        private Button btnNewRec;
    }
}