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

namespace Hospital_Management
{
    public partial class ReceptionistForm : Form
    {
        private Receptionist originalReceptionist;
        public ReceptionistForm()
        {
            InitializeComponent();
            LoadReceptionists();
        }

        private void dataGridViewReceptionists_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewReceptionists.Rows[e.RowIndex];

                originalReceptionist = new Receptionist
                {
                    ReceptionistID = Convert.ToInt32(row.Cells["ReceptionistID"].Value),
                    FullName = row.Cells["FullName"].Value.ToString(),
                    Username = row.Cells["Username"].Value.ToString(),
                    Password = row.Cells["Password"].Value.ToString(),
                    PhoneNumber = row.Cells["PhoneNumber"].Value.ToString()
                };
                txtReceptionistID.Text = originalReceptionist.ReceptionistID.ToString();
                txtFullName.Text = originalReceptionist.FullName;
                txtUsername.Text = originalReceptionist.Username;
                txtPassword.Text = originalReceptionist.Password;
                txtPhoneNumber.Text = originalReceptionist.PhoneNumber;
            }
        }

        private void btnAddRec_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtReceptionistID.Text))
            {
                MessageBox.Show("You cannot create a duplicate receptionist. Please clear the form first.", "Duplicate Patient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name = txtFullName.Text.Trim();

            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Name can only contain letters and spaces.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string phone = txtPhoneNumber.Text.Trim();

            if (!Regex.IsMatch(phone, @"^\d+$"))
            {
                MessageBox.Show("Phone number must contain only digits.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPhoneNumber.Text.Length != 10)
            {
                MessageBox.Show("Phone number must have exactly 10 digits.", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string userName = txtUsername.Text.Trim();

            if (!Regex.IsMatch(userName, @"^[a-zA-Z]{1,10}$"))
            {
                MessageBox.Show("Username must contain only letters (max 10 characters, no numbers or symbols).", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string Password = txtPassword.Text.Trim();

            if (!Regex.IsMatch(Password, @"^[a-zA-Z0-9]{1,12}$"))
            {
                MessageBox.Show("Password must contain only letters and numbers (max 12 characters, no symbols).", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Get form values
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill out all required fields.");
                return;
            }
            using (var context = new HospitalContext())
            {
                // Check if a receptionist with the same attributes already exists
                bool exists = context.Receptionists.Any(rec =>
                    rec.FullName == fullName &&
                    rec.Username == username &&
                    rec.Password == password &&
                    rec.PhoneNumber == phoneNumber
                );

                if (exists)
                {
                    MessageBox.Show("A receptionist with these details already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Add new patient
                var receptionist = new Receptionist
                {
                    FullName = fullName,
                    Username = username,
                    Password = password,
                    PhoneNumber = phoneNumber
                };

                context.Receptionists.Add(receptionist);
                context.SaveChanges();

                MessageBox.Show("Receptionist added successfully!");

                ClearInputs();
                LoadReceptionists();
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
                        rec.Username,
                        rec.Password,
                        rec.PhoneNumber
                    }).ToList();
                dataGridViewReceptionists.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            if (dataGridViewReceptionists.Columns["ReceptionistID"] != null)
            {
                dataGridViewReceptionists.Columns["ReceptionistID"].Visible = false;
            }
        }
        private void ReceptionistForm_Load(object sender, EventArgs e)
        {
            LoadReceptionists();
        }
        private void ClearInputs()
        {
            txtReceptionistID.Clear();
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtPhoneNumber.Clear();
        }
        private void btnNewRec_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnRemoveRec_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtReceptionistID.Text, out int receptionistId))
            {
                MessageBox.Show("Please select a receptionist to delete.");
                return;
            }
            // Optional: Confirm deletion
            var result = MessageBox.Show("Are you sure you want to delete this receptionist?",
                                         "Confirm Deletion",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var context = new HospitalContext())
                {
                    var receptionist = context.Receptionists.Find(receptionistId);

                    if (receptionist != null)
                    {
                        context.Receptionists.Remove(receptionist);
                        context.SaveChanges();

                        MessageBox.Show("Receptionist successfully deleted.");

                        LoadReceptionists();  // Refresh the DataGridView
                        ClearInputs();   // Clear the textboxes 
                    }
                    else
                    {
                        MessageBox.Show("Receptionist not found.");
                    }
                }
            }
        }

        private void btnEditRec_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReceptionistID.Text))
            {
                MessageBox.Show("Please select a receptionist to edit.");
                return;
            }

            if (!int.TryParse(txtReceptionistID.Text, out int Id))
            {
                MessageBox.Show("Invalid receptionist ID.");
                return;
            }
            string name = txtFullName.Text.Trim();

            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Name can only contain letters and spaces.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string phone = txtPhoneNumber.Text.Trim();

            if (!Regex.IsMatch(phone, @"^\d+$"))
            {
                MessageBox.Show("Phone number must contain only digits.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPhoneNumber.Text.Length != 10)
            {
                MessageBox.Show("Phone number must have exactly 10 digits.", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string userName = txtUsername.Text.Trim();

            if (!Regex.IsMatch(userName, @"^[a-zA-Z]{1,10}$"))
            {
                MessageBox.Show("Username must contain only letters (max 10 characters, no numbers or symbols).", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string Password = txtPassword.Text.Trim();

            if (!Regex.IsMatch(Password, @"^[a-zA-Z0-9]{1,12}$"))
            {
                MessageBox.Show("Password must contain only letters and numbers (max 12 characters, no symbols).", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isChanged = txtFullName.Text != originalReceptionist.FullName ||
                             txtUsername.Text != originalReceptionist.Username ||
                             txtPassword.Text != originalReceptionist.Password ||
                             txtPhoneNumber.Text != originalReceptionist.PhoneNumber;
            if (!isChanged)
            {
                MessageBox.Show("You haven't changed any attributes.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var context = new HospitalContext())
            {
                var receptionist = context.Receptionists.Find(originalReceptionist.ReceptionistID);

                if (receptionist != null)
                {
                    receptionist.FullName = txtFullName.Text.Trim();
                    receptionist.Username = txtUsername.Text.Trim();
                    receptionist.Password = txtPassword.Text.Trim();
                    receptionist.PhoneNumber = txtPhoneNumber.Text.Trim();

                    context.SaveChanges();

                    MessageBox.Show("Receptionist successfully updated!");

                    LoadReceptionists();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Receptionist not found in database.");
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}