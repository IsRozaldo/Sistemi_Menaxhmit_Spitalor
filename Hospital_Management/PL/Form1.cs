using Hospital_Management.Core.Data;
using Hospital_Management.Core.Entities;

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
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = User.HashPassword(password);

            using (var context = new HospitalContext())
            {
                // First check if username exists
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                
                if (user == null)
                {
                    MessageBox.Show("Username not found. Please check your username and try again.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    txtUsername.SelectAll();
                    return;
                }

                // Then check if password matches
                if (user.Password != hashedPassword)
                {
                    MessageBox.Show("Incorrect password. Please try again.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
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
                    MessageBox.Show("You do not have permission to access this system.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
