using ClosedXML.Excel;
using Hospital_Management.Core.Data;
using Hospital_Management.Core.Entities;
using Hospital_Management.Core.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Hospital_Management.PL
{
    public partial class BillForm : Form
    {
        private readonly BillManager _billManager = new BillManager();
        private List<Service> selectedServices = new List<Service>();

        public BillForm()
        {
            InitializeComponent();
            LoadPatients();
            LoadServices();
        }

        private void LoadPatients()
        {
            cmbPatient.DataSource = _billManager.GetAllPatients();
            cmbPatient.DisplayMember = "FullName";
            cmbPatient.ValueMember = "Id";
        }

        private void LoadServices()
        {
            var services = _billManager.GetAllServices();
            dataGridViewServices.DataSource = services;

            dataGridViewServices.Columns["ServiceID"].Visible = false;
            dataGridViewServices.Columns["Description"].Visible = true;
            dataGridViewServices.Columns["Category"].Visible = true;

            dataGridViewServices.Columns["Name"].HeaderText = "Service Name";
            dataGridViewServices.Columns["Price"].HeaderText = "Price ($)";

            
        }

        private void dataGridViewServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var service = (Service)dataGridViewServices.Rows[e.RowIndex].DataBoundItem;
                selectedServices.Add(service);
                listBoxSelectedServices.Items.Add($"{service.Name} - ${service.Price}");
                UpdateTotalAmount();
            }
        }

        private void UpdateTotalAmount()
        {
            lblTotalAmount.Text = $"Total: {_billManager.CalculateTotal(selectedServices):C}";
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPatient.SelectedValue == null)
                    throw new ValidationException("Please select a patient.");

                int patientId = Convert.ToInt32(cmbPatient.SelectedValue);
                _billManager.CreateBill(patientId, selectedServices);

                MessageBox.Show("Bill generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            selectedServices.Clear();
            listBoxSelectedServices.Items.Clear();
            lblTotalAmount.Text = "Total: $0.00";
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (selectedServices.Count == 0)
            {
                MessageBox.Show("No services to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.Title = "Save Bill As Excel";
                saveFileDialog.FileName = "Bill.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Bill");

                        worksheet.Cell(1, 1).Value = "Service Name";
                        worksheet.Cell(1, 2).Value = "Price";

                        for (int i = 0; i < selectedServices.Count; i++)
                        {
                            worksheet.Cell(i + 2, 1).Value = selectedServices[i].Name;
                            worksheet.Cell(i + 2, 2).Value = selectedServices[i].Price;
                        }

                        worksheet.Cell(selectedServices.Count + 3, 1).Value = "Total";
                        worksheet.Cell(selectedServices.Count + 3, 2).Value = _billManager.CalculateTotal(selectedServices);

                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Bill exported to Excel successfully!", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRemoveService_Click(object sender, EventArgs e)
        {
            if (listBoxSelectedServices.SelectedIndex >= 0)
            {
                int index = listBoxSelectedServices.SelectedIndex;
                selectedServices.RemoveAt(index);
                listBoxSelectedServices.Items.RemoveAt(index);
                UpdateTotalAmount();
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.CurrentRow != null)
            {
                var service = (Service)dataGridViewServices.CurrentRow.DataBoundItem;
                selectedServices.Add(service);
                listBoxSelectedServices.Items.Add($"{service.Name} - ${service.Price}");
                UpdateTotalAmount();
            }
        }

    }
}
