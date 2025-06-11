using Hospital_Management.Core.Data;
using Hospital_Management.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Hospital_Management.Core.Logic
{
    public class BillManager
    {
        private readonly List<Service> _services;
        private readonly List<Patient> _patients;

        public BillManager()
        {
            
           
        }

        public List<Entities.Patient> GetAllPatients()
        {
            using var context = new HospitalContext();
            return context.Patients.ToList();
        }

        public List<Service> GetAllServices()
        {
            using var context = new HospitalContext();
            return context.Services.ToList();
        }

        public decimal CalculateTotal(List<Service> services)
        {
            return services.Sum(s => s.Price);
        }

        public void CreateBill(int patientId, List<Service> services)
        {
            if (!_patients.Any(p => p.Id == patientId))
                throw new ValidationException("Invalid patient ID.");

            if (services == null || !services.Any())
                throw new ValidationException("No services selected.");

            
        }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}


