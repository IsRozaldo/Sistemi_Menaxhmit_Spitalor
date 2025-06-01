using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string AssignedDoctor { get; set; }
        public string Description { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
