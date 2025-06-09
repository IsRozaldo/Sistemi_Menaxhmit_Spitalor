using Hospital_Management.Core.Data;
using Hospital_Management.Core.Entities;
using Hospital_Management.Core; // Added for custom exceptions

namespace Hospital_Management.PL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Add event handlers for Enter key
            txtUsername.KeyPress += TxtUsername_KeyPress;
            txtPassword.KeyPress += TxtPassword_KeyPress;
        }

        private void TxtUsername_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the beep sound
                txtPassword.Focus(); // Move focus to password textbox
            }
        }

        private void TxtPassword_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the beep sound
                btnLogin_Click(sender, e); // Trigger login button click
            }
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new ValidationException("Please enter both username and password.");
                }

                string hashedPassword = User.HashPassword(password);

                using (var context = new HospitalContext())
                {
                    // First check if username exists
                    var user = context.Users.FirstOrDefault(u => u.Username == username);
                    
                    if (user == null)
                    {
                        throw new NotFoundException("Username not found. Please check your username and try again.");
                    }

                    // Then check if password matches
                    if (user.Password != hashedPassword)
                    {
                        throw new ValidationException("Incorrect password. Please try again.");
                    }

                    // If we get here, both username and password are correct
                    if (user.Role == "Admin" || user.Role == "Receptionist")
                    {
                        MessageBox.Show($"Welcome, {user.FullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Main mn = new Main(user.Role); // Pass the user's role to Main form
                        mn.Show();
                        this.Hide(); // Hide the login form
                    }
                    else
                    {
                        throw new HospitalManagementException("You do not have permission to access this system.");
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                txtUsername.SelectAll();
            }
            catch (HospitalManagementException ex)
            {
                MessageBox.Show(ex.Message, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
