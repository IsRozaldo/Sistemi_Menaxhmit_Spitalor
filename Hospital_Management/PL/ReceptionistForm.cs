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
                    throw new DuplicateEntryException("You cannot create a duplicate receptionist. Please clear the form first.");
                }
                string name = txtFullName.Text.Trim();

                if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
                {
                    throw new ValidationException("Name can only contain letters and spaces.");
                }
                string phone = txtPhoneNumber.Text.Trim();

                if (!Regex.IsMatch(phone, @"^06\d{8}$"))
                {
                    throw new ValidationException("Phone number must start with '06' followed by 8 digits.");
                }

                using (var context = new HospitalContext())
                {
                    string username = txtFullName.Text.Trim().Split(' ')[0];
                    string nameTrimmed = txtFullName.Text.Trim();
                    string phoneTrimmed = txtPhoneNumber.Text.Trim();

                    // Check for duplicate username
                    if (context.Users.Any(u => u.Username == username))
                    {
                        throw new DuplicateEntryException($"A user with the username '{username}' already exists. Please use a different full name or modify the username generation logic.");
                    }

                    // Check for duplicate phone number
                    if (context.Receptionists.Any(r => r.PhoneNumber == phoneTrimmed))
                    {
                        throw new DuplicateEntryException("A receptionist with this phone number already exists.");
                    }

                    // Create new user first
                    var user = new User
                    {
                        Username = username,
                        Password = User.HashPassword("Welcome123"), // Default password
                        Role = "Receptionist",
                        FullName = nameTrimmed,
                        PhoneNumber = phoneTrimmed
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    // Create new receptionist
                    var receptionist = new Receptionist
                    {
                        FullName = nameTrimmed,
                        PhoneNumber = phoneTrimmed,
                        UserID = user.UserID
                    };

                    context.Receptionists.Add(receptionist);
                    context.SaveChanges();

                    MessageBox.Show("Receptionist added successfully!");
                    ClearInputs();
                    LoadReceptionists();
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
            try
            {
                if (string.IsNullOrWhiteSpace(txtReceptionistID.Text) || originalReceptionist == null)
                {
                    throw new ValidationException("Please select a receptionist to edit.");
                }

                if (!int.TryParse(txtReceptionistID.Text, out int Id))
                {
                    throw new ValidationException("Invalid receptionist ID.");
                }
                string name = txtFullName.Text.Trim();

                if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
                {
                    throw new ValidationException("Name can only contain letters and spaces.");
                }
                string phone = txtPhoneNumber.Text.Trim();

                if (!Regex.IsMatch(phone, @"^\d+$"))
                {
                    throw new ValidationException("Phone number must contain only digits.");
                }
                if (txtPhoneNumber.Text.Length != 10)
                {
                    throw new ValidationException("Phone number must have exactly 10 digits.");
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
                        throw new NotFoundException("Receptionist not found in database.");
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

        private void btnRemoveRec_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtReceptionistID.Text) || originalReceptionist == null)
                {
                    throw new ValidationException("Please select a receptionist to remove.");
                }

                if (!int.TryParse(txtReceptionistID.Text, out int Id))
                {
                    throw new ValidationException("Invalid receptionist ID.");
                }

                using (var context = new HospitalContext())
                {
                    var receptionist = context.Receptionists.Find(Id);
                    if (receptionist != null)
                    {
                        var user = context.Users.Find(receptionist.UserID);
                        if (user != null)
                        {
                            // Optional: Confirm deletion
                            var result = MessageBox.Show("Are you sure you want to remove the receptionist?",
                                                         "Confirm Deletion",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Warning);

                            if (result == DialogResult.Yes)
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
                            throw new NotFoundException("User associated with receptionist not found.");
                        }
                    }
                    else
                    {
                        throw new NotFoundException("Receptionist not found in database.");
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