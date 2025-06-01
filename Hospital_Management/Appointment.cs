using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        public int ReceptionistID { get; set; }
        public Receptionist Receptionist { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
