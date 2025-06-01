using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class Receptionist
    {
        public int ReceptionistID { get; set; } 
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
