using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management.PL
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PatientForm pf = new PatientForm();
            pf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doctors df = new Doctors();
            df.Show();
        }

        private void btnReceptionists_Click(object sender, EventArgs e)
        {
            ReceptionistForm receptionistForm = new ReceptionistForm();
            receptionistForm.Show();
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            AppointmentForm appointmentForm = new AppointmentForm();
            appointmentForm.Show();
        }
    }
}