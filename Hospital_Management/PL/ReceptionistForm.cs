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

                txtReceptionistID.Text = originalReceptionist.ReceptionistID.ToString();
                txtFullName.Text = originalReceptionist.FullName;
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

            using (var context = new HospitalContext())
            {
                // Create new user first
                var user = new User
                {
                    Username = txtFullName.Text.Trim().Split(' ')[0], // Use first name as username
                    Password = User.HashPassword("Welcome123"), // Default password
                    Role = "Receptionist",
                    FullName = txtFullName.Text.Trim(),
                    PhoneNumber = txtPhoneNumber.Text.Trim()
                };

                context.Users.Add(user);
                context.SaveChanges();

                // Create new receptionist
                var receptionist = new Receptionist
                {
                    FullName = txtFullName.Text.Trim(),
                    PhoneNumber = txtPhoneNumber.Text.Trim(),
                    UserID = user.UserID
                };

                context.Receptionists.Add(receptionist);
                context.SaveChanges();

                MessageBox.Show("Receptionist added successfully! Default password is 'Welcome123'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        }

        private void btnNewRec_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnEditRec_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReceptionistID.Text) || originalReceptionist == null)
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

            bool isChanged = txtFullName.Text != originalReceptionist.FullName ||
                            txtPhoneNumber.Text != originalReceptionist.PhoneNumber;

            if (!isChanged)
            {
                MessageBox.Show("You haven't changed any attributes.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var context = new HospitalContext())
            {
                var receptionist = context.Receptionists.Find(originalReceptionist.ReceptionistID);
                var user = context.Users.Find(receptionist?.UserID);

                if (receptionist != null && user != null)
                {
                    receptionist.FullName = txtFullName.Text.Trim();
                    receptionist.PhoneNumber = txtPhoneNumber.Text.Trim();
                    user.FullName = txtFullName.Text.Trim();
                    user.PhoneNumber = txtPhoneNumber.Text.Trim();

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

        private void btnRemoveRec_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReceptionistID.Text) || originalReceptionist == null)
            {
                MessageBox.Show("Please select a receptionist to remove.");
                return;
            }

            if (!int.TryParse(txtReceptionistID.Text, out int Id))
            {
                MessageBox.Show("Invalid receptionist ID.");
                return;
            }

            using (var context = new HospitalContext())
            {
                var receptionist = context.Receptionists.Find(Id);
                if (receptionist != null)
                {
                    var user = context.Users.Find(receptionist.UserID);
                    if (user != null)
                    {
                        context.Receptionists.Remove(receptionist);
                        context.Users.Remove(user);
                        context.SaveChanges();

                        MessageBox.Show("Receptionist successfully removed!");

                        LoadReceptionists();
                        ClearInputs();
                    }
                }
                else
                {
                    MessageBox.Show("Receptionist not found in database.");
                }
            }
        }
    }
}