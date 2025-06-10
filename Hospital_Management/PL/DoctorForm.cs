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
    public partial class DoctorForm : Form
    {
        private Doctor? originalDoctor;
        public DoctorForm()
        {
            InitializeComponent();
            cmbSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;

            // Add KeyPress handlers for Enter key navigation
            txtFullName.KeyPress += TextBox_KeyPress;
            txtPhone.KeyPress += TextBox_KeyPress;
            txtOfficeNumber.KeyPress += TextBox_KeyPress;

            Logger.LogInfo("DoctorForm initialized");
        }

        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDoctors.Rows[e.RowIndex];

                originalDoctor = new Doctor
                {
                    DoctorID = Convert.ToInt32(row.Cells["DoctorID"].Value),
                    FullName = row.Cells["FullName"].Value?.ToString() ?? string.Empty,
                    Specialty = row.Cells["Specialty"].Value?.ToString() ?? string.Empty,
                    PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString() ?? string.Empty,
                    OfficeNumber = row.Cells["OfficeNumber"].Value?.ToString() ?? string.Empty
                };

                // Fill the form with doctor information
                txtDoctorID.Text = originalDoctor.DoctorID.ToString();
                txtFullName.Text = originalDoctor.FullName;
                cmbSpecialty.Text = originalDoctor.Specialty;
                txtPhone.Text = originalDoctor.PhoneNumber;
                txtOfficeNumber.Text = originalDoctor.OfficeNumber;

                // Disable the Add button and enable the Edit button
                button4.Enabled = false;
                button2.Enabled = true;

                Logger.LogInfo($"Doctor selected: {originalDoctor.FullName} (ID: {originalDoctor.DoctorID})");
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            ClearInputs();
            Logger.LogInfo("New doctor form cleared");
        }

        private void txtPhone_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Max length: 10 digits
            if (txtPhone.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // If first digit is entered, ensure it's '0'
            if (txtPhone.Text.Length == 0 && e.KeyChar != '0')
            {
                e.Handled = true;
            }

            // If second digit is entered, ensure it's '6'
            if (txtPhone.Text.Length == 1 && e.KeyChar != '6')
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtDoctorID.Text))
                {
                    throw new DuplicateEntryException("Doctor", txtDoctorID.Text,
                        "You cannot create a duplicate doctor. Please clear the form first.");
                }

                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    throw new ValidationException("Full Name is required.");
                }

                if (cmbSpecialty.SelectedIndex == -1)
                {
                    throw new ValidationException("Specialty is required.");
                }

                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    throw new ValidationException("Phone Number is required.");
                }

                if (string.IsNullOrWhiteSpace(txtOfficeNumber.Text))
                {
                    throw new ValidationException("Office Number is required.");
                }

                using (var context = new HospitalContext())
                {
                    var doctor = new Doctor
                    {
                        FullName = txtFullName.Text,
                        Specialty = cmbSpecialty.SelectedItem.ToString(),
                        PhoneNumber = txtPhone.Text,
                        OfficeNumber = txtOfficeNumber.Text
                    };

                    context.Doctors.Add(doctor);
                    context.SaveChanges();

                    Logger.LogInfo($"New doctor added: {doctor.FullName} (ID: {doctor.DoctorID})");
                    MessageBox.Show("Doctor added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDoctors();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error adding doctor", ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDoctorID.Text) || originalDoctor == null)
                {
                    throw new ValidationException("Please select a doctor to edit.");
                }

                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    throw new ValidationException("Full Name is required.");
                }

                if (cmbSpecialty.SelectedIndex == -1)
                {
                    throw new ValidationException("Specialty is required.");
                }

                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    throw new ValidationException("Phone Number is required.");
                }

                if (string.IsNullOrWhiteSpace(txtOfficeNumber.Text))
                {
                    throw new ValidationException("Office Number is required.");
                }

                using (var context = new HospitalContext())
                {
                    var doctor = context.Doctors.Find(Convert.ToInt32(txtDoctorID.Text));
                    if (doctor != null)
                    {
                        doctor.FullName = txtFullName.Text;
                        doctor.Specialty = cmbSpecialty.SelectedItem.ToString();
                        doctor.PhoneNumber = txtPhone.Text;
                        doctor.OfficeNumber = txtOfficeNumber.Text;

                        context.SaveChanges();

                        Logger.LogInfo($"Doctor updated: {doctor.FullName} (ID: {doctor.DoctorID})");
                        MessageBox.Show("Doctor updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDoctors();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error updating doctor", ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDoctorID.Text))
                {
                    throw new ValidationException("Please select a doctor to remove.");
                }

                var result = MessageBox.Show("Are you sure you want to remove this doctor?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var context = new HospitalContext())
                    {
                        var doctor = context.Doctors.Find(Convert.ToInt32(txtDoctorID.Text));
                        if (doctor != null)
                        {
                            context.Doctors.Remove(doctor);
                            context.SaveChanges();

                            Logger.LogInfo($"Doctor removed: {doctor.FullName} (ID: {doctor.DoctorID})");
                            MessageBox.Show("Doctor removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDoctors();
                            ClearInputs();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error removing doctor", ex);
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

        private void LoadDoctors()
        {
            using (var context = new HospitalContext())
            {
                dataGridViewDoctors.DataSource = context.Doctors
                    .Select(d => new
                    {
                        d.DoctorID,
                        d.FullName,
                        d.Specialty,
                        d.PhoneNumber,
                        d.OfficeNumber
                    }).ToList();
                dataGridViewDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            if (dataGridViewDoctors.Columns["DoctorID"] != null)
            {
                dataGridViewDoctors.Columns["DoctorID"].Visible = false;
            }
            Logger.LogInfo("Doctor list loaded");
        }

        private void ClearInputs()
        {
            txtDoctorID.Clear();
            txtFullName.Clear();
            cmbSpecialty.SelectedIndex = -1;
            txtPhone.Clear();
            txtOfficeNumber.Clear();
            button4.Enabled = true;
            button2.Enabled = false;
        }

        private void DoctorForm_Load(object? sender, EventArgs e)
        {
            LoadDoctors();
        }
    }
}