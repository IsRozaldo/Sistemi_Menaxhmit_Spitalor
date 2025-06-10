using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital_Management.Core.Data;
using Hospital_Management.Core.Entities;
using Hospital_Management.Core; // Added for custom exceptions
using Hospital_Management.Core.Utilities;

namespace Hospital_Management.PL
{
    public partial class ReceptionistForm : Form
    {
        private Receptionist? originalReceptionist;
        private string userRole;

        public ReceptionistForm(string role)
        {
            InitializeComponent();
            userRole = role;
            LoadReceptionists();
            SetButtonAccess();

            // Add KeyPress handlers for Enter key navigation
            txtFullName.KeyPress += TextBox_KeyPress;
            txtPhoneNumber.KeyPress += TextBox_KeyPress;

            Logger.LogInfo("ReceptionistForm initialized");
        }

        private void SetButtonAccess()
        {
            // Only Admin can add, edit, or remove receptionists
            bool isAdmin = userRole == "Admin";
            btnAddRec.Enabled = isAdmin;
            btnEditRec.Enabled = isAdmin;
            btnRemoveRec.Enabled = isAdmin;
            btnNewRec.Enabled = isAdmin;

            // If not admin, make the form read-only
            if (!isAdmin)
            {
                txtFullName.ReadOnly = true;
                txtPhoneNumber.ReadOnly = true;
                dataGridViewReceptionists.ReadOnly = true;
            }
        }

        private void dataGridViewReceptionists_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewReceptionists.Rows[e.RowIndex];

                originalReceptionist = new Receptionist
                {
                    ReceptionistID = Convert.ToInt32(row.Cells["ReceptionistID"].Value),
                    FullName = row.Cells["FullName"].Value?.ToString() ?? string.Empty,
                    PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString() ?? string.Empty,
                    UserID = Convert.ToInt32(row.Cells["UserID"].Value)
                };

                // Fill the form with receptionist information
                txtReceptionistID.Text = originalReceptionist.ReceptionistID.ToString();
                txtFullName.Text = originalReceptionist.FullName;
                txtPhoneNumber.Text = originalReceptionist.PhoneNumber;

                // Disable the Add button and enable the Edit button
                btnAddRec.Enabled = false;
                btnEditRec.Enabled = true;

                Logger.LogInfo($"Receptionist selected: {originalReceptionist.FullName} (ID: {originalReceptionist.ReceptionistID})");
            }
        }

        private void txtPhoneNumber_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Max length: 10 digits
            if (txtPhoneNumber.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // If first digit is entered, ensure it's '0'
            if (txtPhoneNumber.Text.Length == 0 && e.KeyChar != '0')
            {
                e.Handled = true;
            }

            // If second digit is entered, ensure it's '6'
            if (txtPhoneNumber.Text.Length == 1 && e.KeyChar != '6')
            {
                e.Handled = true;
            }
        }

        private void btnAddRec_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtReceptionistID.Text))
                {
                    throw new DuplicateEntryException("Receptionist", txtReceptionistID.Text,
                        "You cannot create a duplicate receptionist. Please clear the form first.");
                }

                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    throw new ValidationException("Full Name is required.");
                }

                if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    throw new ValidationException("Phone Number is required.");
                }

                using (var context = new HospitalContext())
                {
                    var receptionist = new Receptionist
                    {
                        FullName = txtFullName.Text,
                        PhoneNumber = txtPhoneNumber.Text
                    };

                    context.Receptionists.Add(receptionist);
                    context.SaveChanges();

                    Logger.LogInfo($"New receptionist added: {receptionist.FullName} (ID: {receptionist.ReceptionistID})");
                    MessageBox.Show("Receptionist added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReceptionists();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error adding receptionist", ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReceptionists()
        {
            using (var context = new HospitalContext())
            {
                dataGridViewReceptionists.DataSource = context.Receptionists
                    .Select(rec => new
                    {
                        rec.ReceptionistID,
                        rec.FullName,
                        rec.PhoneNumber,
                        rec.UserID
                    }).ToList();
                dataGridViewReceptionists.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            if (dataGridViewReceptionists.Columns["ReceptionistID"] != null)
            {
                dataGridViewReceptionists.Columns["ReceptionistID"].Visible = false;
            }
            if (dataGridViewReceptionists.Columns["UserID"] != null)
            {
                dataGridViewReceptionists.Columns["UserID"].Visible = false;
            }
            Logger.LogInfo("Receptionist list loaded");
        }

        private void ReceptionistForm_Load(object sender, EventArgs e)
        {
            LoadReceptionists();
        }

        private void ClearInputs()
        {
            txtReceptionistID.Clear();
            txtFullName.Clear();
            txtPhoneNumber.Clear();
            btnAddRec.Enabled = true;
            btnEditRec.Enabled = false;
        }

        private void btnNewRec_Click(object sender, EventArgs e)
        {
            ClearInputs();
            Logger.LogInfo("New receptionist form cleared");
        }

        private void btnEditRec_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtReceptionistID.Text) || originalReceptionist == null)
                {
                    throw new ValidationException("Please select a receptionist to edit.");
                }

                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    throw new ValidationException("Full Name is required.");
                }

                if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    throw new ValidationException("Phone Number is required.");
                }

                using (var context = new HospitalContext())
                {
                    var receptionist = context.Receptionists.Find(Convert.ToInt32(txtReceptionistID.Text));
                    if (receptionist != null)
                    {
                        receptionist.FullName = txtFullName.Text;
                        receptionist.PhoneNumber = txtPhoneNumber.Text;

                        context.SaveChanges();

                        Logger.LogInfo($"Receptionist updated: {receptionist.FullName} (ID: {receptionist.ReceptionistID})");
                        MessageBox.Show("Receptionist updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReceptionists();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error updating receptionist", ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveRec_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtReceptionistID.Text))
                {
                    throw new ValidationException("Please select a receptionist to remove.");
                }

                var result = MessageBox.Show("Are you sure you want to remove this receptionist?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var context = new HospitalContext())
                    {
                        var receptionist = context.Receptionists.Find(Convert.ToInt32(txtReceptionistID.Text));
                        if (receptionist != null)
                        {
                            context.Receptionists.Remove(receptionist);
                            context.SaveChanges();

                            Logger.LogInfo($"Receptionist removed: {receptionist.FullName} (ID: {receptionist.ReceptionistID})");
                            MessageBox.Show("Receptionist removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadReceptionists();
                            ClearInputs();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error removing receptionist", ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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