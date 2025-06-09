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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
           //optionsBuilder.UseSqlServer("Data Source=ROZALDO\\SQLEXPRESS02;Initial Catalog=HospitalDB;Integrated Security=True;Trust Server Certificate=True");
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Trust Server Certificate=True;");

        }
    }
}