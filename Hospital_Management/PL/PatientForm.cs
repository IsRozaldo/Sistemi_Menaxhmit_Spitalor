using Azure;
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
    public partial class PatientForm : Form
    {
        private Patient? originalPatient;
        public PatientForm()
        {
            InitializeComponent();
            LoadDoctorsIntoComboBox(); 
            txtPhoneNumber.KeyPress += TxtPhoneNumber_KeyPress;
            txtAge.KeyPress += txtAge_KeyPress;
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignedDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Load += new System.EventHandler(this.PatientForm_Load);

            // Add KeyPress handlers for Enter key navigation
            txtFullName.KeyPress += TextBox_KeyPress;
            txtAge.KeyPress += TextBox_KeyPress;
            txtPhoneNumber.KeyPress += TextBox_KeyPress;
            txtDescription.KeyPress += TextBox_KeyPress;

            Logger.LogInfo("PatientForm initialized");
        }
        private void TxtPhoneNumber_KeyPress(object? sender, KeyPressEventArgs e)
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
        private void txtAge_KeyPress(object? sender, KeyPressEventArgs e)
        {
            try
            {
                // Allow only digits and control keys (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Stop the character from being entered
                    throw new ValidationException("Only numbers are allowed in the age field.");
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDoctorsIntoComboBox()
        {
            using (var context = new HospitalContext())
            {
                var doctors = context.Doctors.ToList();
                cmbAssignedDoctor.DataSource = doctors;
                cmbAssignedDoctor.DisplayMember = "FullName";
                cmbAssignedDoctor.ValueMember = "DoctorID";
                cmbAssignedDoctor.SelectedIndex = -1;
            }
        }

        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPatients.Rows[e.RowIndex];

                originalPatient = new Patient
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    FullName = row.Cells["FullName"].Value?.ToString() ?? string.Empty,
                    Age = Convert.ToInt32(row.Cells["Age"].Value),
                    Gender = row.Cells["Gender"].Value?.ToString() ?? string.Empty,
                    PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString() ?? string.Empty,
                    AssignedDoctor = row.Cells["AssignedDoctor"].Value?.ToString() ?? string.Empty,
                    Description = row.Cells["Description"].Value?.ToString() ?? string.Empty
                };

                // Fill the form with patient information
                txtPatientID.Text = originalPatient.Id.ToString();
                txtFullName.Text = originalPatient.FullName;
                txtAge.Text = originalPatient.Age.ToString();
                cmbGender.SelectedItem = originalPatient.Gender;
                txtPhoneNumber.Text = originalPatient.PhoneNumber;
                cmbAssignedDoctor.Text = originalPatient.AssignedDoctor;
                txtDescription.Text = originalPatient.Description;

                // Disable the Add button and enable the Edit button
                btnAddPatient.Enabled = false;
                btnEditPatient.Enabled = true;
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtPatientID.Text))
                {
                    throw new DuplicateEntryException("Patient", txtPatientID.Text, 
                        "You cannot create a duplicate patient. Please clear the form first.");
                }

                string fullName = txtFullName.Text.Trim();
                
                // Validate full name format
                if (!Regex.IsMatch(fullName, @"^[a-zA-Z]+\s+[a-zA-Z]+$"))
                {
                    throw new ValidationException("FullName", fullName, 
                        "Full name must contain both first and last name, and can only contain alphabetical letters.");
                }

                string phoneNumber = txtPhoneNumber.Text.Trim();
                string gender = cmbGender.SelectedItem?.ToString() ?? string.Empty;
                string assignedTo = cmbAssignedDoctor.SelectedItem?.ToString() ?? string.Empty;
                string description = txtDescription.Text.Trim();

                if (!int.TryParse(txtAge.Text, out int age))
                {
                    throw new ValidationException("Age", txtAge.Text, "Please enter a valid age.");
                }

                // Basic validation
                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber) || 
                    int.IsNegative(age) || string.IsNullOrWhiteSpace(gender) || 
                    string.IsNullOrWhiteSpace(assignedTo) || string.IsNullOrWhiteSpace(description))
                {
                    throw new ValidationException("RequiredFields", new { FullName = fullName, Age = age, Gender = gender }, 
                        "Please fill out all required fields.");
                }

                if (!Regex.IsMatch(phoneNumber, @"^06\d{8}$"))
                {
                    throw new ValidationException("PhoneNumber", phoneNumber, 
                        "Phone number must start with '06' followed by 8 digits.");
                }

                if (txtDescription.Text.Length > 150)
                {
                    throw new ValidationException("Description", description, 
                        "The description cannot be longer than 150 characters.");
                }

                using (var context = new HospitalContext())
                {
                    try
                    {
                        // Check if a patient with the same phone number already exists
                        if (context.Patients.Any(p => p.PhoneNumber == phoneNumber))
                        {
                            throw new DuplicateEntryException("Patient", phoneNumber, 
                                "A patient with this phone number already exists.");
                        }

                        // Add new patient
                        var patient = new Patient
                        {
                            FullName = fullName,
                            Age = age,
                            Gender = gender,
                            PhoneNumber = phoneNumber,
                            AssignedDoctor = assignedTo,
                            Description = description
                        };

                        context.Patients.Add(patient);
                        context.SaveChanges();

                        Logger.LogInfo($"New patient added: {patient.FullName} (ID: {patient.Id})");
                        MessageBox.Show("Patient added successfully!");
                        ClearInputs();
                        LoadPatients();
                    }
                    catch (Exception ex) when (ex is not DuplicateEntryException && ex is not ValidationException)
                    {
                        throw new DatabaseException("Insert", 
                            $"Failed to add patient to database: {ex.Message}");
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"Validation Error: {ex.Message}\nProperty: {ex.PropertyName}\nValue: {ex.AttemptedValue}", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DuplicateEntryException ex)
            {
                MessageBox.Show($"Duplicate Entry: {ex.Message}\nEntity: {ex.EntityName}\nValue: {ex.KeyValue}", 
                    "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\nOperation: {ex.Operation}", 
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Logger.LogError("Error adding patient", ex);
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPatients()
        {
            using (var context = new HospitalContext())
            {
                dataGridViewPatients.DataSource = context.Patients
                    .Select(p => new
                    {
                        p.Id,
                        p.FullName,
                        p.PhoneNumber,
                        p.Age,
                        p.Gender,
                        p.AssignedDoctor,
                        p.Description,
                    }).ToList();
                dataGridViewPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            if (dataGridViewPatients.Columns["Id"] != null)
            {
                dataGridViewPatients.Columns["Id"].Visible = false;
            }
        }
        private void PatientForm_Load(object? sender, EventArgs e)
        {
            LoadPatients();
            Logger.LogInfo("Patient list loaded");
        }
        private void ClearInputs()
        {
            txtPatientID.Clear();
            txtFullName.Clear();
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;
            txtPhoneNumber.Clear();
            cmbAssignedDoctor.SelectedIndex = -1; 
            txtDescription.Clear();
        }

        private void btnEditPatient_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPatientID.Text) || originalPatient == null)
                {
                    throw new ValidationException("Please select a patient to edit.");
                }

                if (!int.TryParse(txtPatientID.Text, out int Id))
                {
                    throw new ValidationException("Invalid patient ID.");
                }
                if (txtPhoneNumber.Text.Length != 10)
                {
                    throw new ValidationException("Phone number must have exactly 10 digits.");
                }
                string fullName = txtFullName.Text.Trim();

                if (!Regex.IsMatch(fullName, @"^[a-zA-Z\s]+$"))
                {
                    throw new ValidationException("You cannot edit a patient by adding numbers or symbols to the patient name.");
                }
                int Age = int.Parse(txtAge.Text);

                if (Age < 0 || Age > 100)
                {
                    throw new ValidationException("Age must be between 0 and 100.");
                }

                bool isChanged = txtFullName.Text != originalPatient.FullName ||
                                txtAge.Text != originalPatient.Age.ToString() ||
                                (cmbGender.SelectedItem?.ToString() ?? string.Empty) != originalPatient.Gender ||
                                txtPhoneNumber.Text != originalPatient.PhoneNumber ||
                                cmbAssignedDoctor.Text != originalPatient.AssignedDoctor ||
                                txtDescription.Text != originalPatient.Description;

                if (!isChanged)
                {
                    MessageBox.Show("You haven't changed any attributes.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var context = new HospitalContext())
                {
                    var patient = context.Patients.Find(originalPatient.Id);

                    if (patient != null)
                    {
                        patient.FullName = txtFullName.Text;
                        patient.Age = int.Parse(txtAge.Text);
                        patient.Gender = cmbGender.SelectedItem?.ToString() ?? string.Empty;
                        patient.PhoneNumber = txtPhoneNumber.Text;
                        patient.AssignedDoctor = cmbAssignedDoctor.Text;
                        patient.Description = txtDescription.Text;

                        context.SaveChanges();

                        Logger.LogInfo($"Patient updated: {patient.FullName} (ID: {patient.Id})");
                        MessageBox.Show("Patient successfully updated!");

                        LoadPatients();
                        ClearInputs();    
                    }
                    else
                    {
                        throw new NotFoundException("Patient not found in database.");
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
                Logger.LogError("Error updating patient", ex);
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPatientID.Text))
                {
                    throw new ValidationException("PatientID", txtPatientID.Text, 
                        "Please select a patient to remove.");
                }

                if (!int.TryParse(txtPatientID.Text, out int patientId))
                {
                    throw new ValidationException("PatientID", txtPatientID.Text, 
                        "Invalid patient ID.");
                }

                var result = MessageBox.Show("Are you sure you want to remove the patient?",
                                             "Confirm Deletion",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (var context = new HospitalContext())
                    {
                        try
                        {
                            var patient = context.Patients.Find(patientId);

                            if (patient != null)
                            {
                                context.Patients.Remove(patient);
                                context.SaveChanges();

                                Logger.LogInfo($"Patient removed: {patient.FullName} (ID: {patient.Id})");
                                MessageBox.Show("Patient removed successfully.");
                                LoadPatients();
                                ClearInputs();
                            }
                            else
                            {
                                throw new NotFoundException("Patient", patientId.ToString(), 
                                    "Patient not found in database.");
                            }
                        }
                        catch (Exception ex) when (ex is not NotFoundException)
                        {
                            throw new DatabaseException("Delete", 
                                $"Failed to remove patient from database: {ex.Message}");
                        }
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"Validation Error: {ex.Message}\nProperty: {ex.PropertyName}\nValue: {ex.AttemptedValue}", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show($"Not Found: {ex.Message}\nEntity: {ex.EntityName}\nID: {ex.KeyValue}", 
                    "Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\nOperation: {ex.Operation}", 
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Logger.LogError("Error removing patient", ex);
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewPatient_Click(object? sender, EventArgs e)
        {
            ClearInputs();
            Logger.LogInfo("New patient form cleared");
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadPatients();
            Logger.LogInfo("Patient list refreshed");
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