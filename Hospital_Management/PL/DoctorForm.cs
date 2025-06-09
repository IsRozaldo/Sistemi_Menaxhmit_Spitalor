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
                txtDoctorID.Text = originalDoctor.DoctorID.ToString();
                txtFullName.Text = originalDoctor.FullName;
                cmbSpecialty.Text = originalDoctor.Specialty;
                txtPhone.Text = originalDoctor.PhoneNumber;
                txtOfficeNumber.Text = originalDoctor.OfficeNumber;
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            ClearInputs(); 
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
                    throw new DuplicateEntryException("You cannot create a duplicate Doctor. Please clear the form first.");
                }
                string fullName = txtFullName.Text.Trim();
                
                // Validate full name format
                if (!Regex.IsMatch(fullName, @"^[a-zA-Z]+\s+[a-zA-Z]+$"))
                {
                    throw new ValidationException("Full name must contain both first and last name, and can only contain alphabetical letters.");
                }

                string specialty = cmbSpecialty.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string officeNumber = txtOfficeNumber.Text.Trim();

                // Basic validation
                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(specialty) || string.IsNullOrWhiteSpace(officeNumber))
                {
                    throw new ValidationException("Please fill out all required fields.");
                }

                if (!Regex.IsMatch(phone, @"^06\d{8}$"))
                {
                    throw new ValidationException("Phone number must start with '06' followed by 8 digits.");
                }

                if (!Regex.IsMatch(officeNumber, @"^[A-Z]\d{3}$"))
                {
                    throw new ValidationException("Office number must start with a capital letter followed by exactly 3 digits.");
                }

                using (var context = new HospitalContext())
                {
                    // Check if a doctor with the same phone number already exists
                    if (context.Doctors.Any(d => d.PhoneNumber == phone))
                    {
                        throw new DuplicateEntryException("A doctor with this phone number already exists.");
                    }

                    // Add new doctor
                    var doctor = new Doctor
                    {
                        FullName = fullName,
                        Specialty = specialty,
                        PhoneNumber = phone,
                        OfficeNumber = officeNumber
                    };

                    context.Doctors.Add(doctor);
                    context.SaveChanges();

                    MessageBox.Show("Doctor added successfully!");

                    ClearInputs();
                    LoadDoctors();
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DuplicateEntryException ex)
            {
                MessageBox.Show(ex.Message, "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDoctors()
        {
            using (var context = new HospitalContext())
            {
                dataGridViewDoctors.DataSource = context.Doctors
                     .Select(d => new
                     {
                         d.FullName,
                         d.PhoneNumber,
                         d.Specialty,
                         d.OfficeNumber,
                         d.DoctorID
                     }).ToList();
                dataGridViewDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            if (dataGridViewDoctors.Columns["DoctorID"] != null)
            {
                dataGridViewDoctors.Columns["DoctorID"].Visible = false;
            }
        }
        private void DoctorForm_Load(object? sender, EventArgs e)
        {
            LoadDoctors(); // Load doctors into the DataGridView when the form loads
        }
        private void ClearInputs()
        {
            txtDoctorID.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtOfficeNumber.Clear();
            cmbSpecialty.SelectedIndex = -1;
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtDoctorID.Text, out int doctorId))
                {
                    throw new ValidationException("Please select a doctor to delete.");
                }

                // Optional: Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this doctor?",
                                             "Confirm Deletion",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (var context = new HospitalContext())
                    {
                        var doctor = context.Doctors.Find(doctorId);

                        if (doctor != null)
                        {
                            context.Doctors.Remove(doctor);
                            context.SaveChanges();

                            MessageBox.Show("Doctor successfully deleted.");

                            LoadDoctors();  // Refresh the DataGridView
                            ClearInputs();   // Clear the textboxes (optional)
                        }
                        else
                        {
                            throw new NotFoundException("Doctor not found.");
                        }
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDoctorID.Text) || originalDoctor == null)
                {
                    throw new ValidationException("Please select a doctor to edit.");
                }

                if (!int.TryParse(txtDoctorID.Text, out int Id))
                {
                    throw new ValidationException("Invalid doctor ID.");
                }

                if (txtPhone.Text.Length != 10)
                {
                    throw new ValidationException("Phone number must have exactly 10 digits.");
                }

                string fullName = txtFullName.Text.Trim();

                if (!Regex.IsMatch(fullName, @"^[a-zA-Z\s]+$"))
                {
                    throw new ValidationException("You cannot edit a patient by adding numbers or symbols to the patient name.");
                }
                
                string officeNumber = txtOfficeNumber.Text.Trim();

                if (!Regex.IsMatch(officeNumber, @"^[A-Z]\d{3}$"))
                {
                    throw new ValidationException("Office number must start with a capital letter followed by exactly 3 digits.");
                }

                bool isChanged = txtFullName.Text != originalDoctor.FullName ||
                                cmbSpecialty.Text != originalDoctor.Specialty ||
                                txtPhone.Text != originalDoctor.PhoneNumber ||
                                txtOfficeNumber.Text != originalDoctor.OfficeNumber;
                if (!isChanged)
                {
                    MessageBox.Show("You haven't changed any attributes.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var context = new HospitalContext())
                {
                    var doctor = context.Doctors.Find(originalDoctor.DoctorID);

                    if (doctor != null)
                    {
                        doctor.FullName = txtFullName.Text;
                        doctor.PhoneNumber = txtPhone.Text;
                        doctor.Specialty = cmbSpecialty.Text;
                        doctor.OfficeNumber = txtOfficeNumber.Text;

                        context.SaveChanges();

                        MessageBox.Show("Doctor successfully updated!");

                        LoadDoctors();
                        ClearInputs();
                    }
                    else
                    {
                        throw new NotFoundException("Doctor not found in database.");
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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