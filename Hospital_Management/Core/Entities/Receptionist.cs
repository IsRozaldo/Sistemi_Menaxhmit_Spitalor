using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management.Core.Entities;
using System.Security.Cryptography;

namespace Hospital_Management.Core.Entities
{
    public class Receptionist
    {
        public int ReceptionistID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int UserID { get; set; }  // Foreign key to User table
        public User User { get; set; }   // Navigation property
        public ICollection<Appointment> Appointments { get; set; }

        public Receptionist()
        {
            FullName = string.Empty;
            PhoneNumber = string.Empty;
            User = null!; // Initialize as null to satisfy non-nullable warning, assuming it will be loaded from DB
            Appointments = new List<Appointment>();
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
