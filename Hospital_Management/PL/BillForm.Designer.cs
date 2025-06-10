namespace Hospital_Management.PL
{
    partial class BillForm
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
            cmbPatient = new ComboBox();
            lblPatient = new Label();
            dataGridViewServices = new DataGridView();
            lblAvailableServices = new Label();
            btnAddService = new Button();
            btnRemoveService = new Button();
            listBoxSelectedServices = new ListBox();
            lblSelectedServices = new Label();
            lblTotalAmount = new Label();
            btnGenerateBill = new Button();
            btnExportToExcel = new Button();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbPatient
            // 
            cmbPatient.FormattingEnabled = true;
            cmbPatient.Location = new Point(117, 92);
            cmbPatient.Name = "cmbPatient";
            cmbPatient.Size = new Size(200, 28);
            cmbPatient.TabIndex = 0;
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPatient.Location = new Point(31, 92);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(80, 28);
            lblPatient.TabIndex = 1;
            lblPatient.Text = "Patient:";
            // 
            // dataGridViewServices
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewServices.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewServices.Location = new Point(30, 165);
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewServices.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewServices.RowHeadersWidth = 51;
            dataGridViewServices.Size = new Size(491, 280);
            dataGridViewServices.TabIndex = 2;
            // 
            // lblAvailableServices
            // 
            lblAvailableServices.AutoSize = true;
            lblAvailableServices.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblAvailableServices.Location = new Point(30, 134);
            lblAvailableServices.Name = "lblAvailableServices";
            lblAvailableServices.Size = new Size(178, 28);
            lblAvailableServices.TabIndex = 3;
            lblAvailableServices.Text = "Available Services:";
            // 
            // btnAddService
            // 
            btnAddService.BackColor = Color.BurlyWood;
            btnAddService.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAddService.Location = new Point(99, 464);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(161, 53);
            btnAddService.TabIndex = 4;
            btnAddService.Text = "Add Service";
            btnAddService.UseVisualStyleBackColor = false;
            btnAddService.Click += btnAddService_Click;
            // 
            // btnRemoveService
            // 
            btnRemoveService.BackColor = Color.BurlyWood;
            btnRemoveService.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnRemoveService.Location = new Point(266, 464);
            btnRemoveService.Name = "btnRemoveService";
            btnRemoveService.Size = new Size(169, 53);
            btnRemoveService.TabIndex = 5;
            btnRemoveService.Text = "Remove Service";
            btnRemoveService.UseVisualStyleBackColor = false;
            btnRemoveService.Click += btnRemoveService_Click;
            // 
            // listBoxSelectedServices
            // 
            listBoxSelectedServices.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBoxSelectedServices.FormattingEnabled = true;
            listBoxSelectedServices.ItemHeight = 28;
            listBoxSelectedServices.Location = new Point(527, 189);
            listBoxSelectedServices.Name = "listBoxSelectedServices";
            listBoxSelectedServices.Size = new Size(361, 256);
            listBoxSelectedServices.TabIndex = 6;
            // 
            // lblSelectedServices
            // 
            lblSelectedServices.AutoSize = true;
            lblSelectedServices.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblSelectedServices.Location = new Point(527, 158);
            lblSelectedServices.Name = "lblSelectedServices";
            lblSelectedServices.Size = new Size(174, 28);
            lblSelectedServices.TabIndex = 7;
            lblSelectedServices.Text = "Selected Services:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.Location = new Point(323, 538);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(96, 41);
            lblTotalAmount.TabIndex = 8;
            lblTotalAmount.Text = "Total:";
            // 
            // btnGenerateBill
            // 
            btnGenerateBill.BackColor = Color.BurlyWood;
            btnGenerateBill.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnGenerateBill.Location = new Point(540, 464);
            btnGenerateBill.Name = "btnGenerateBill";
            btnGenerateBill.Size = new Size(161, 54);
            btnGenerateBill.TabIndex = 9;
            btnGenerateBill.Text = "Generate Bill";
            btnGenerateBill.UseVisualStyleBackColor = false;
            btnGenerateBill.Click += btnGenerateBill_Click;
            // 
            // btnExportToExcel
            // 
            btnExportToExcel.BackColor = Color.BurlyWood;
            btnExportToExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnExportToExcel.Location = new Point(716, 463);
            btnExportToExcel.Name = "btnExportToExcel";
            btnExportToExcel.Size = new Size(161, 54);
            btnExportToExcel.TabIndex = 11;
            btnExportToExcel.Text = "Export to Excel";
            btnExportToExcel.UseVisualStyleBackColor = false;
            btnExportToExcel.Click += btnExportToExcel_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Wheat;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(900, 72);
            panel1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(297, 9);
            label1.Name = "label1";
            label1.Size = new Size(275, 50);
            label1.TabIndex = 0;
            label1.Text = "Generate a bill";
            // 
            // BillForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(900, 602);
            Controls.Add(btnExportToExcel);
            Controls.Add(panel1);
            Controls.Add(btnGenerateBill);
            Controls.Add(lblTotalAmount);
            Controls.Add(lblSelectedServices);
            Controls.Add(listBoxSelectedServices);
            Controls.Add(btnRemoveService);
            Controls.Add(btnAddService);
            Controls.Add(lblAvailableServices);
            Controls.Add(dataGridViewServices);
            Controls.Add(lblPatient);
            Controls.Add(cmbPatient);
            Name = "BillForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BillForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPatient;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.Label lblAvailableServices;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnRemoveService;
        private System.Windows.Forms.ListBox listBoxSelectedServices;
        private System.Windows.Forms.Label lblSelectedServices;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnGenerateBill;
        private System.Windows.Forms.Button btnExportToExcel;
        private Panel panel1;
        private Label label1;
    }
} 