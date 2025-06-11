using Hospital_Management.Core.Data;
using Hospital_Management.Core.Entities;
using Hospital_Management.Core; 

namespace Hospital_Management.PL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            txtUsername.KeyPress += TxtUsername_KeyPress;//event handler
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
                e.Handled = true; 
                btnLogin_Click(sender, e); 
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new ValidationException("Credentials", new { Username = username, Password = "****" }, 
                        "Please enter both username and password.");
                }

                string hashedPassword = User.HashPassword(password);

                using (var context = new HospitalContext())
                {
                    //nqs ekziston useri
                    var user = context.Users.FirstOrDefault(u => u.Username == username);
                    
                    if (user == null)
                    {
                        throw new NotFoundException("User", username, 
                            "Username not found. Please check your username and try again.");
                    }

                    // nqs passwordi i sakte
                    if (user.Password != hashedPassword)
                    {
                        throw new AuthenticationException(username, 
                            "Incorrect password. Please try again.");
                    }

                    // nqs te dyja sakte
                    if (user.Role == "Admin" || user.Role == "Receptionist")
                    {
                        MessageBox.Show($"Welcome, {user.FullName}!", "Login Successful", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Main mn = new Main(user.Role); // ndarja sipas rolit
                        mn.Show();
                        this.Hide(); // fsheh login formen
                    }
                    else
                    {
                        throw new AuthorizationException("Admin/Receptionist", user.Role, 
                            "You do not have permission to access this system.");
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"Validation Error: {ex.Message}\nProperty: {ex.PropertyName}", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show($"Not Found: {ex.Message}\nEntity: {ex.EntityName}", 
                    "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                txtUsername.SelectAll();
            }
            catch (AuthenticationException ex)
            {
                MessageBox.Show($"Authentication Failed: {ex.Message}\nUsername: {ex.Username}", 
                    "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
            catch (AuthorizationException ex)
            {
                MessageBox.Show($"Access Denied: {ex.Message}\nRequired Role: {ex.RequiredRole}\nYour Role: {ex.UserRole}", 
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
