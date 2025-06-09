using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Receptionist>()
                .HasOne(r => r.User)
                .WithOne()
                .HasForeignKey<Receptionist>(r => r.UserID);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithOne()
                .HasForeignKey<Admin>(a => a.UserID);

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
                    Username = "Dardan",
                    Password = User.HashPassword("Hoxha2024"),
                    Role = "Receptionist",
                    FullName = "Dardan Hoxha",
                    PhoneNumber = "9876543210"
                },
                new User
                {
                    UserID = 3,
                    Username = "Ermal",
                    Password = User.HashPassword("Berisha2024"),
                    Role = "Receptionist",
                    FullName = "Ermal Berisha",
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
                    FullName = "Dardan Hoxha",
                    PhoneNumber = "9876543210"
                },
                new Receptionist
                {
                    ReceptionistID = 2,
                    UserID = 3,
                    FullName = "Ermal Berisha",
                    PhoneNumber = "5555555555"
                }
            );
        }
    }
}