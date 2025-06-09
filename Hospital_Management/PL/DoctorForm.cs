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
    public partial class Doctors : Form
    {
        private Doctor originalDoctor;
        public Doctors()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Doctors_Load);
            cmbSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDoctors.Rows[e.RowIndex];

                originalDoctor = new Doctor
                {
                    DoctorID = Convert.ToInt32(row.Cells["DoctorID"].Value),
                    FullName = row.Cells["FullName"].Value.ToString(),
                    Specialty = row.Cells["Specialty"].Value.ToString(),
                    PhoneNumber = row.Cells["PhoneNumber"].Value.ToString(),
                    OfficeNumber = row.Cells["OfficeNumber"].Value.ToString()
                };
                txtDoctorID.Text = originalDoctor.DoctorID.ToString();
                txtFullName.Text = originalDoctor.FullName;
                cmbSpecialty.Text = originalDoctor.Specialty;
                txtPhone.Text = originalDoctor.PhoneNumber;
                txtOfficeNumber.Text = originalDoctor.OfficeNumber;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputs(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDoctorID.Text))
            {
                MessageBox.Show("You cannot create a duplicate Doctor. Please clear the form first.", "Duplicate Doctor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string fullName = txtFullName.Text.Trim();
            string specialty = cmbSpecialty.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string officeNumber = txtOfficeNumber.Text.Trim();

            // Basic validation (optional but recommended)
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(specialty) || string.IsNullOrWhiteSpace(officeNumber))
            {
                MessageBox.Show("Please fill out all required fields.");
                return;
            }

            if (!Regex.IsMatch(fullName, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("You cannot add numbers or symbols to the doctors name.");
                return;
            }
            if (!Regex.IsMatch(txtPhone.Text, @"^\d{9,15}$"))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }
            if (txtPhone.Text.Length != 10)
            {
                MessageBox.Show("Phone number must have exactly 10 digits.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(officeNumber, @"^[A-Z]\d{3}$"))
            {
                MessageBox.Show("Office number must start with a capital letter followed by exactly 3 digits.", "Invalid Office Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                    MessageBox.Show("A doctor with these details already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
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
        private void Doctors_Load_1(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDoctorID.Text, out int doctorId))
            {
                MessageBox.Show("Please select a doctor to delete.");
                return;
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
                        MessageBox.Show("Doctor not found.");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorID.Text))
            {
                MessageBox.Show("Please select a doctor to edit.");
                return;
            }

            if (!int.TryParse(txtDoctorID.Text, out int Id))
            {
                MessageBox.Show("Invalid doctor ID.");
                return;
            }

            if (txtPhone.Text.Length != 10)
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
            
            string officeNumber = txtOfficeNumber.Text.Trim();

            if (!Regex.IsMatch(officeNumber, @"^[A-Z]\d{3}$"))
            {
                MessageBox.Show("Office number must start with a capital letter followed by exactly 3 digits.", "Invalid Office Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                    MessageBox.Show("Doctor was not found in database.");
                }
            }
        }
    }
}