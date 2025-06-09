using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.Core.Entities
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int UserID { get; set; }  // Foreign key to User table
        public User User { get; set; }   // Navigation property

        public Admin()
        {
            FullName = string.Empty;
            PhoneNumber = string.Empty;
            User = null!; // Initialize as null to satisfy non-nullable warning, assuming it will be loaded from DB
        }
    }
} 