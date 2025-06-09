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
            this.components = new System.ComponentModel.Container();
            this.cmbPatient = new System.Windows.Forms.ComboBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.lblAvailableServices = new System.Windows.Forms.Label();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnRemoveService = new System.Windows.Forms.Button();
            this.listBoxSelectedServices = new System.Windows.Forms.ListBox();
            this.lblSelectedServices = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnGenerateBill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPatient
            // 
            this.cmbPatient.FormattingEnabled = true;
            this.cmbPatient.Location = new System.Drawing.Point(140, 30);
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new System.Drawing.Size(200, 28);
            this.cmbPatient.TabIndex = 0;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(30, 33);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(57, 20);
            this.lblPatient.TabIndex = 1;
            this.lblPatient.Text = "Patient:";
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Location = new System.Drawing.Point(30, 100);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.RowHeadersWidth = 51;
            this.dataGridViewServices.Size = new System.Drawing.Size(310, 150);
            this.dataGridViewServices.TabIndex = 2;
            // 
            // lblAvailableServices
            // 
            this.lblAvailableServices.AutoSize = true;
            this.lblAvailableServices.Location = new System.Drawing.Point(30, 77);
            this.lblAvailableServices.Name = "lblAvailableServices";
            this.lblAvailableServices.Size = new System.Drawing.Size(127, 20);
            this.lblAvailableServices.TabIndex = 3;
            this.lblAvailableServices.Text = "Available Services:";
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(30, 260);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(150, 30);
            this.btnAddService.TabIndex = 4;
            this.btnAddService.Text = "Add Service";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnRemoveService
            // 
            this.btnRemoveService.Location = new System.Drawing.Point(190, 260);
            this.btnRemoveService.Name = "btnRemoveService";
            this.btnRemoveService.Size = new System.Drawing.Size(150, 30);
            this.btnRemoveService.TabIndex = 5;
            this.btnRemoveService.Text = "Remove Service";
            this.btnRemoveService.UseVisualStyleBackColor = true;
            this.btnRemoveService.Click += new System.EventHandler(this.btnRemoveService_Click);
            // 
            // listBoxSelectedServices
            // 
            this.listBoxSelectedServices.FormattingEnabled = true;
            this.listBoxSelectedServices.ItemHeight = 20;
            this.listBoxSelectedServices.Location = new System.Drawing.Point(380, 100);
            this.listBoxSelectedServices.Name = "listBoxSelectedServices";
            this.listBoxSelectedServices.Size = new System.Drawing.Size(250, 190);
            this.listBoxSelectedServices.TabIndex = 6;
            // 
            // lblSelectedServices
            // 
            this.lblSelectedServices.AutoSize = true;
            this.lblSelectedServices.Location = new System.Drawing.Point(380, 77);
            this.lblSelectedServices.Name = "lblSelectedServices";
            this.lblSelectedServices.Size = new System.Drawing.Size(124, 20);
            this.lblSelectedServices.TabIndex = 7;
            this.lblSelectedServices.Text = "Selected Services:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalAmount.Location = new System.Drawing.Point(30, 310);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(73, 28);
            this.lblTotalAmount.TabIndex = 8;
            this.lblTotalAmount.Text = "Total:";
            // 
            // btnGenerateBill
            // 
            this.btnGenerateBill.Location = new System.Drawing.Point(30, 350);
            this.btnGenerateBill.Name = "btnGenerateBill";
            this.btnGenerateBill.Size = new System.Drawing.Size(150, 40);
            this.btnGenerateBill.TabIndex = 9;
            this.btnGenerateBill.Text = "Generate Bill";
            this.btnGenerateBill.UseVisualStyleBackColor = true;
            this.btnGenerateBill.Click += new System.EventHandler(this.btnGenerateBill_Click);
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 420);
            this.Controls.Add(this.btnGenerateBill);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblSelectedServices);
            this.Controls.Add(this.listBoxSelectedServices);
            this.Controls.Add(this.btnRemoveService);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.lblAvailableServices);
            this.Controls.Add(this.dataGridViewServices);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.cmbPatient);
            this.Name = "BillForm";
            this.Text = "BillForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
} 