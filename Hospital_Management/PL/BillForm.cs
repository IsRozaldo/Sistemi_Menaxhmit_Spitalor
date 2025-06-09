using System;
using System.Windows.Forms;
using Hospital_Management.Core.Data;
using Hospital_Management.Core.Entities;
using System.Linq;
using System.Collections.Generic;
using Hospital_Management.Core;

namespace Hospital_Management.PL
{
    public partial class BillForm : Form
    {
        private List<Service> selectedServices = new List<Service>();

        public BillForm()
        {
            InitializeComponent();
            LoadPatients();
            LoadServices();
            UpdateTotalAmount();

            // Add KeyPress handlers for Enter key navigation
            cmbPatient.KeyPress += TextBox_KeyPress;
        }

        private void LoadPatients()
        {
            using (var context = new HospitalContext())
            {
                var patients = context.Patients.ToList();
                cmbPatient.DisplayMember = "FullName";
                cmbPatient.ValueMember = "PatientID";
                cmbPatient.DataSource = patients;
            }
        }

        private void LoadServices()
        {
            using (var context = new HospitalContext())
            {
                var services = context.Services.ToList();
                dataGridViewServices.DataSource = services;
                dataGridViewServices.Columns["ServiceID"].Visible = false;
                dataGridViewServices.Columns["Description"].Visible = false;
                dataGridViewServices.Columns["Category"].Visible = false;
                dataGridViewServices.Columns["Name"].HeaderText = "Service Name";
                dataGridViewServices.Columns["Price"].HeaderText = "Price ($)";
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = selectedServices.Sum(s => s.Price);
            lblTotalAmount.Text = $"Total: {total:C}";
        }

        private void btnAddService_Click(object? sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                var selectedService = (Service)dataGridViewServices.SelectedRows[0].DataBoundItem;
                if (selectedService != null && !selectedServices.Any(s => s.ServiceID == selectedService.ServiceID))
                {
                    selectedServices.Add(selectedService);
                    UpdateSelectedServicesList();
                    UpdateTotalAmount();
                }
            }
            else
            {
                MessageBox.Show("Please select a service to add.", "No Service Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoveService_Click(object? sender, EventArgs e)
        {
            if (listBoxSelectedServices.SelectedItem is Service serviceToRemove)
            {
                selectedServices.Remove(serviceToRemove);
                UpdateSelectedServicesList();
                UpdateTotalAmount();
            }
            else
            {
                MessageBox.Show("Please select a service to remove from the selected list.", "No Service Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateSelectedServicesList()
        {
            listBoxSelectedServices.DataSource = null;
            listBoxSelectedServices.DisplayMember = "Name";
            listBoxSelectedServices.ValueMember = "ServiceID";
            listBoxSelectedServices.DataSource = selectedServices.ToList();
        }

        private void btnGenerateBill_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cmbPatient.SelectedValue == null)
                {
                    throw new ValidationException("Please select a patient.");
                }
                if (selectedServices.Count == 0)
                {
                    throw new ValidationException("Please add at least one service.");
                }

                int patientId = Convert.ToInt32(cmbPatient.SelectedValue);
                decimal totalAmount = selectedServices.Sum(s => s.Price);
                string servicesJson = System.Text.Json.JsonSerializer.Serialize(selectedServices);

                using (var context = new HospitalContext())
                {
                    var newBill = new Bill
                    {
                        PatientID = patientId,
                        BillDate = DateTime.Now,
                        TotalAmount = totalAmount,
                        Services = servicesJson,
                        Status = "Pending", // Default status
                        CreatedAt = DateTime.Now
                    };

                    context.Bills.Add(newBill);
                    context.SaveChanges();

                    MessageBox.Show("Bill generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
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
            cmbPatient.SelectedIndex = -1;
            selectedServices.Clear();
            UpdateSelectedServicesList();
            UpdateTotalAmount();
        }

        private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the beep sound
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
} 