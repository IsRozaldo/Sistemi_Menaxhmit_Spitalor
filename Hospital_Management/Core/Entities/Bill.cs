using System;
using System.Collections.Generic;

namespace Hospital_Management.Core.Entities
{
    public class Bill
    {
        public int BillID { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; } = null!;
        public DateTime BillDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Services { get; set; } = string.Empty; // Store as JSON string
        public string Status { get; set; } = "Pending"; // Pending, Paid, Cancelled
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 