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

namespace Hospital_Management.PL
{
    public partial class PatientForm : Form
    {
        private Patient originalPatient;
        public PatientForm()
        {
            InitializeComponent();
            LoadDoctorsIntoComboBox(); 
            txtPhoneNumber.KeyPress += TxtPhoneNumber_KeyPress;
            txtAge.KeyPress += txtAge_KeyPress;
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignedDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Load += new System.EventHandler(this.PatientForm_Load);
        }
        private void TxtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Max length: +355 (4) + 9 digits = 13 characters
            if (txtPhoneNumber.Text.Length >= 13 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Stop the character from being entered
                MessageBox.Show("Only numbers are allowed in the age field.");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPatients.Rows[e.RowIndex];

                originalPatient = new Patient
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    FullName = row.Cells["FullName"].Value.ToString(),
                    Age = Convert.ToInt32(row.Cells["Age"].Value),
                    Gender = row.Cells["Gender"].Value.ToString(),
                    PhoneNumber = row.Cells["PhoneNumber"].Value.ToString(),
                    AssignedDoctor = row.Cells["AssignedDoctor"].Value.ToString(),
                    Description = row.Cells["Description"].Value.ToString()
                };

                txtPatientID.Text = originalPatient.Id.ToString();
                txtFullName.Text = originalPatient.FullName;
                txtAge.Text = originalPatient.Age.ToString();
                cmbGender.SelectedItem = originalPatient.Gender;
                txtPhoneNumber.Text = originalPatient.PhoneNumber;
                cmbAssignedDoctor.Text = originalPatient.AssignedDoctor;
                txtDescription.Text = originalPatient.Description;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPatientID.Text))
            {
                MessageBox.Show("You cannot create a duplicate patient. Please clear the form first.", "Duplicate Patient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get form values
            string fullName = txtFullName.Text.Trim();
            int age = int.TryParse(txtAge.Text, out int a) ? a : 0;
            string gender = cmbGender.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string assignedTo = cmbAssignedDoctor.Text.Trim();
            string description = txtDescription.Text.Trim();

            // Basic validation (optional but recommended)
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber) || int.IsNegative(age) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(assignedTo) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill out all required fields.");
                return;
            }

            if (!Regex.IsMatch(fullName, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("You cannot add numbers or symbols to the patient name.");
                return;
            }

            if (!Regex.IsMatch(txtPhoneNumber.Text, @"^\d{9,15}$"))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }
            if (txtPhoneNumber.Text.Length != 10)
            {
                MessageBox.Show("Phone number must have exactly 10 digits.", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDescription.Text.Length > 150)
            {
                MessageBox.Show("The description cannot be longer than 250 characters.");
                return;
            }
            using (var context = new HospitalContext())
            {
                // Check if a patient with the same attributes already exists
                bool exists = context.Patients.Any(p =>
                    p.FullName == fullName &&
                    p.Age == age &&
                    p.Gender == gender &&
                    p.PhoneNumber == phoneNumber &&
                    p.AssignedDoctor == assignedTo &&
                    p.Description == description
                );

                if (exists)
                {
                    MessageBox.Show("A patient with these details already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
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

                MessageBox.Show("Patient added successfully!");

                ClearInputs();
                LoadPatients();
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
        private void PatientForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
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

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientID.Text))
            {
                MessageBox.Show("Please select a patient to edit.");
                return;
            }

            if (!int.TryParse(txtPatientID.Text, out int Id))
            {
                MessageBox.Show("Invalid patient ID.");
                return;
            }
            if (txtPhoneNumber.Text.Length != 10)
            {
                MessageBox.Show("Phone number must have exactly 10 digits.", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string fullName = txtFullName.Text.Trim();

            if (!Regex.IsMatch(fullName, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("You cannot edit a patient by adding numbers or symbols to the patient name.");
                return;
            }
            int Age = int.Parse(txtAge.Text);

            if (Age < 0 || Age > 100)
            {
                MessageBox.Show("Age must be between 0 and 100.");
                return;
            }

            bool isChanged = txtFullName.Text != originalPatient.FullName ||
                            txtAge.Text != originalPatient.Age.ToString() ||
                            cmbGender.SelectedItem.ToString() != originalPatient.Gender ||
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
                    patient.Gender = cmbGender.SelectedItem.ToString();
                    patient.PhoneNumber = txtPhoneNumber.Text;
                    patient.AssignedDoctor = cmbAssignedDoctor.Text;
                    patient.Description = txtDescription.Text;


                    context.SaveChanges();

                    MessageBox.Show("Patient successfully updated!");

                    LoadPatients();
                    ClearInputs();    
                }
                else
                {
                    MessageBox.Show("Patient not found in database.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPatientID.Text, out int patientId))
            {
                MessageBox.Show("Please select a patient to delete.");
                return;
            }

            // Optional: Confirm deletion
            var result = MessageBox.Show("Are you sure you want to delete this patient?",
                                         "Confirm Deletion",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var context = new HospitalContext())
                {
                    var patient = context.Patients.Find(patientId);

                    if (patient != null)
                    {
                        context.Patients.Remove(patient);
                        context.SaveChanges();

                        MessageBox.Show("Patient successfully deleted.");

                        LoadPatients();  // Refresh the DataGridView
                        ClearInputs();   // Clear the textboxes (optional)
                    }
                    else
                    {
                        MessageBox.Show("Patient not found.");
                    }
                }
            }
        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDoctorsIntoComboBox();
        }
    }
}