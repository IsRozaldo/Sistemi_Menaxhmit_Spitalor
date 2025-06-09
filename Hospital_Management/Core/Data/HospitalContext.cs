using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospital_Management.Core.Entities;

namespace Hospital_Management.Core.Data
{
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Trust Server Certificate=True;");
            //optionsBuilder.UseSqlServer("Data Source=ROZALDO\\SQLEXPRESS2;Initial Catalog=HospitalDB;Integrated Security=True;Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorID);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Receptionist)
                .WithMany(r => r.Appointments)
                .HasForeignKey(a => a.ReceptionistID);

            modelBuilder.Entity<Receptionist>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserID);

            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Patient)
                .WithMany()
                .HasForeignKey(b => b.PatientID);

            // Seed default admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    Username = "Arlind",
                    Password = User.HashPassword("Krasniqi2024"),
                    Role = "Admin",
                    FullName = "Arlind Krasniqi",
                    PhoneNumber = "1234567890"
                },
                new User
                {
                    UserID = 2,
                    Username = "aldo",
                    Password = User.HashPassword("1"),
                    Role = "Receptionist",
                    FullName = "RoZaldo",
                    PhoneNumber = "9876543210"
                },
                new User
                {
                    UserID = 3,
                    Username = "helena",
                    Password = User.HashPassword("332"),
                    Role = "Receptionist",
                    FullName = "Helena",
                    PhoneNumber = "5555555555"
                }
            );

            // Seed admin
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminID = 1,
                    UserID = 1,
                    FullName = "Arlind Krasniqi",
                    PhoneNumber = "1234567890"
                }
            );

            // Seed receptionists
            modelBuilder.Entity<Receptionist>().HasData(
                new Receptionist
                {
                    ReceptionistID = 1,
                    UserID = 2,
                    FullName = "RoZaldo",
                    PhoneNumber = "9876543210"
                },
                new Receptionist
                {
                    ReceptionistID = 2,
                    UserID = 3,
                    FullName = "Helena",
                    PhoneNumber = "5555555555"
                }
            );

            // Seed default services
            var services = new[]
            {
                new Service { ServiceID = 1, Name = "General Consultation", Description = "Standard doctor consultation", Price = 50.00m, Category = "Consultation" },
                new Service { ServiceID = 2, Name = "Specialist Consultation", Description = "Specialist doctor consultation", Price = 100.00m, Category = "Consultation" },
                new Service { ServiceID = 3, Name = "Blood Test", Description = "Complete blood count", Price = 30.00m, Category = "Laboratory" },
                new Service { ServiceID = 4, Name = "X-Ray", Description = "Standard X-Ray imaging", Price = 80.00m, Category = "Imaging" },
                new Service { ServiceID = 5, Name = "MRI Scan", Description = "Magnetic Resonance Imaging", Price = 300.00m, Category = "Imaging" },
                new Service { ServiceID = 6, Name = "ECG", Description = "Electrocardiogram", Price = 60.00m, Category = "Diagnostic" },
                new Service { ServiceID = 7, Name = "Ultrasound", Description = "Ultrasound examination", Price = 120.00m, Category = "Imaging" },
                new Service { ServiceID = 8, Name = "Vaccination", Description = "Standard vaccination", Price = 40.00m, Category = "Treatment" }
            };

            modelBuilder.Entity<Service>().HasData(services);

            // Add unique constraints for phone numbers
            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Doctor>()
                .HasIndex(d => d.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Receptionist>()
                .HasIndex(r => r.PhoneNumber)
                .IsUnique();
        }
    }
}