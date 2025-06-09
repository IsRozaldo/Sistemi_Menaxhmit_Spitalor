namespace Hospital_Management.Core.Entities
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty; // e.g., Consultation, Laboratory, Imaging, etc.
    }
} 