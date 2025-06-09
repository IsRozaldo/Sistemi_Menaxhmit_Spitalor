using System;
using System.Windows.Forms;

namespace Hospital_Management.PL
{
    public partial class Main : Form
    {
        private string userRole;

        public Main(string role)
        {
            InitializeComponent();
            userRole = role;
            SetButtonAccess();
        }

        private void SetButtonAccess()
        {
            bool isAdmin = userRole == "Admin";
            
            // Show all buttons for Admin
            btnReceptionists.Visible = isAdmin;
            button2.Visible = isAdmin; // Doctor button
            button1.Visible = true; // Patient button
            btnAppointment.Visible = true; // Appointment button
            button5.Visible = true; // Bill button
            button7.Visible = false; // Medical Record button (hidden for both roles)
            btnLogOut.Visible = true; // Logout button
        }

        private void btnReceptionists_Click(object sender, EventArgs e)
        {
            ReceptionistForm receptionistForm = new ReceptionistForm(userRole);
            receptionistForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoctorForm doctorForm = new DoctorForm();
            doctorForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientForm patientForm = new PatientForm();
            patientForm.Show();
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            AppointmentForm appointmentForm = new AppointmentForm();
            appointmentForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BillForm billForm = new BillForm();
            billForm.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}