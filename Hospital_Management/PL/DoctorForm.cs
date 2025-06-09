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

        private void button4_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtDoctorID.Text))
                {
                    throw new DuplicateEntryException("You cannot create a duplicate Doctor. Please clear the form first.");
                }
                string fullName = txtFullName.Text.Trim();
                string specialty = cmbSpecialty.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string officeNumber = txtOfficeNumber.Text.Trim();

                // Basic validation (optional but recommended)
                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(specialty) || string.IsNullOrWhiteSpace(officeNumber))
                {
                    throw new ValidationException("Please fill out all required fields.");
                }

                if (!Regex.IsMatch(fullName, @"^[a-zA-Z\s]+$"))
                {
                    throw new ValidationException("You cannot add numbers or symbols to the doctors name.");
                }
                if (!Regex.IsMatch(txtPhone.Text, @"^\d{9,15}$"))
                {
                    throw new ValidationException("Please enter a valid phone number.");
                }
                if (txtPhone.Text.Length != 10)
                {
                    throw new ValidationException("Phone number must have exactly 10 digits.");
                }
                if (!Regex.IsMatch(officeNumber, @"^[A-Z]\d{3}$"))
                {
                    throw new ValidationException("Office number must start with a capital letter followed by exactly 3 digits.");
                }

                using (var context = new HospitalContext())
                {
                    // Check if a doctor with the same attributes already exists
                    bool exists = context.Doctors.Any(d =>
                        d.FullName == fullName &&
                        d.PhoneNumber == (phone) &&
                        d.Specialty == specialty &&
                        d.OfficeNumber == officeNumber
                    );

                    if (exists)
                    {
                        throw new DuplicateEntryException("A doctor with these details already exists.");
                    }

                    // Add new patient
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
    }
}