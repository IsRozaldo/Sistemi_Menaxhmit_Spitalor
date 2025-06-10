using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital_Management.Core.Data;
using Hospital_Management.Core.Entities;
using Hospital_Management.Core;
using Hospital_Management.Core.Utilities;

namespace Hospital_Management.PL
{
    public partial class AppointmentForm : Form
    {
        private int originalPatientID;
        private Appointment? originalAppointment;
        public AppointmentForm()
        {
            InitializeComponent();
            cmbSelectPatient.SelectedIndexChanged += cmbSelectPatient_SelectedIndexChanged;
            dataGridViewAppointments.CellClick += dataGridViewAppointments_CellClick;
            cmbCreatedBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignedTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadPatientsIntoComboBox();
            LoadReceptionistsIntoComboBox();
            LoadDoctorsIntoComboBox();
            LoadDoctorsIntoFilterComboBox();
            LoadPatientsIntoFilterComboBox();
            LoadAppointmentsToGrid(null, null, null);
            Logger.LogInfo("AppointmentForm initialized");
        }
        private void LoadPatientsIntoComboBox()
        {
            using (var context = new HospitalContext())
            {
                var patients = context.Patients.ToList();
                cmbSelectPatient.DataSource = patients;
                cmbSelectPatient.DisplayMember = "FullName";
                cmbSelectPatient.ValueMember = "Id";
            }
        }
        private void LoadDoctorsIntoComboBox()
        {
            using (var context = new HospitalContext())
            {
                var doctors = context.Doctors.ToList();
                cmbAssignedTo.DataSource = doctors;
                cmbAssignedTo.DisplayMember = "FullName";
                cmbAssignedTo.ValueMember = "DoctorID";
            }
        }
        private void LoadReceptionistsIntoComboBox()
        {
            using (var context = new HospitalContext())
            {
                var receptionists = context.Receptionists.ToList();
                cmbCreatedBy.DataSource = receptionists;
                cmbCreatedBy.DisplayMember = "FullName";
                cmbCreatedBy.ValueMember = "ReceptionistID";
            }
        }
        private void LoadDoctorsIntoFilterComboBox()
        {
            using (var context = new HospitalContext())
            {
                var doctors = context.Doctors.ToList();
                doctors.Insert(0, new Doctor { DoctorID = 0, FullName = "All Doctors" }); // Add a default "All" option
                cmbFilterDoctor.DataSource = doctors;
                cmbFilterDoctor.DisplayMember = "FullName";
                cmbFilterDoctor.ValueMember = "DoctorID";
            }
        }

        private void LoadPatientsIntoFilterComboBox()
        {
            using (var context = new HospitalContext())
            {
                var patients = context.Patients.ToList();
                patients.Insert(0, new Patient { Id = 0, FullName = "All Patients" }); // Add a default "All" option
                cmbFilterPatient.DataSource = patients;
                cmbFilterPatient.DisplayMember = "FullName";
                cmbFilterPatient.ValueMember = "Id";
            }
        }
        private void dataGridViewAppointments_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAppointments.Rows[e.RowIndex];

                int appointmentId = Convert.ToInt32(row.Cells["AppointmentID"].Value);
                using (var context = new HospitalContext())
                {
                    var appointment = context.Appointments
                                             .Include(a => a.Patient)
                                             .FirstOrDefault(a => a.AppointmentID == appointmentId);

                    if (appointment != null)
                    {
                        cmbSelectPatient.SelectedValue = appointment.PatientID;
                        originalPatientID = appointment.PatientID;
                        txtAge.Text = appointment.Age.ToString();
                        txtGender.Text = appointment.Gender;
                        cmbAssignedTo.SelectedValue = appointment.DoctorID;
                        cmbCreatedBy.SelectedValue = appointment.ReceptionistID;
                        dateTimePickerScheduled.Value = appointment.ScheduledDate;
                    }
                }
            }
        }
        private void LoadAppointmentsToGrid(int? doctorId, int? patientId, DateTime? scheduledDate)
        {
            using (var context = new HospitalContext())
            {
                var query = context.Appointments
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor)
                    .Include(a => a.Receptionist)
                    .AsQueryable();

                if (doctorId.HasValue && doctorId.Value != 0)
                {
                    query = query.Where(a => a.DoctorID == doctorId.Value);
                }

                if (patientId.HasValue && patientId.Value != 0)
                {
                    query = query.Where(a => a.PatientID == patientId.Value);
                }

                if (scheduledDate.HasValue)
                {
                    query = query.Where(a => a.ScheduledDate.Date == scheduledDate.Value.Date);
                }

                var appointments = query.Select(a => new
                {
                    a.AppointmentID,
                    PatientName = a.Patient.FullName,
                    DoctorName = a.Doctor.FullName,
                    ReceptionistName = a.Receptionist.FullName,
                    a.Age,
                    a.Gender,
                    a.CreatedAt,
                    a.ScheduledDate
                })
                .ToList();

                dataGridViewAppointments.DataSource = appointments;
            }
            if (dataGridViewAppointments.Columns["AppointmentID"] != null)
            {
                dataGridViewAppointments.Columns["AppointmentID"].Visible = false;
            }
        }

        private void cmbSelectPatient_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbSelectPatient.SelectedItem is Patient selectedPatient)
            {
                cmbAssignedTo.Text = selectedPatient.AssignedDoctor;
                txtAge.Text = selectedPatient.Age.ToString();
                txtGender.Text = selectedPatient.Gender;
            }
            else
            {
                // Handle the case where SelectedItem is null or not a Patient object
                cmbAssignedTo.Text = string.Empty;
                txtAge.Text = string.Empty;
                txtGender.Text = string.Empty;
            }
        }
        private void ClearForm()
        {
            cmbSelectPatient.SelectedIndex = -1;
            txtAge.Clear();
            txtGender.Clear();
            cmbAssignedTo.SelectedIndex = -1;
            cmbCreatedBy.SelectedIndex = -1;
            dateTimePickerScheduled.Value = DateTime.Now;
            txtAppointmentID.Clear(); // Clear appointment ID when clearing form
        }
        private void btnAddRec_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cmbSelectPatient.SelectedItem == null)
                {
                    throw new ValidationException("Patient", null, 
                        "Please select a patient!");
                }

                if (string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(txtGender.Text))
                {
                    throw new ValidationException("Age/Gender", null, 
                        "Please fill in age and gender!");
                }

                if (cmbAssignedTo.SelectedItem == null)
                {
                    throw new ValidationException("Doctor", null, 
                        "Please assign a doctor!");
                }

                if (cmbCreatedBy.SelectedItem == null)
                {
                    throw new ValidationException("Receptionist", null, 
                        "Please select the receptionist who will create the appointment!");
                }

                using (var context = new HospitalContext())
                {
                    int selectedPatientId = (int?)cmbSelectPatient.SelectedValue ?? 0;
                    DateTime selectedDate = dateTimePickerScheduled.Value.Date;

                    bool appointmentExists = context.Appointments
                        .Any(a => a.PatientID == selectedPatientId && a.ScheduledDate.Date == selectedDate);

                    if (appointmentExists)
                    {
                        throw new DuplicateEntryException("Appointment", 
                            new { PatientID = selectedPatientId, ScheduledDate = selectedDate }, 
                            "An appointment for this patient is already added on this date.");
                    }
                    var appointment = new Appointment
                    {
                        PatientID = (int?)cmbSelectPatient.SelectedValue ?? 0,
                        DoctorID = (int?)cmbAssignedTo.SelectedValue ?? 0,
                        Age = int.Parse(txtAge.Text),
                        Gender = txtGender.Text,
                        ReceptionistID = (int?)cmbCreatedBy.SelectedValue ?? 0,
                        CreatedAt = DateTime.Now,
                        ScheduledDate = dateTimePickerScheduled.Value,
                    };
                    try
                    {
                        context.Appointments.Add(appointment);
                        context.SaveChanges();
                        MessageBox.Show("Appointment successfully added!");
                        LoadAppointmentsToGrid(null, null, null);
                        ClearForm();
                        Logger.LogInfo($"New appointment added: ID {appointment.AppointmentID} for patient {cmbSelectPatient.Text} with doctor {cmbAssignedTo.Text}");
                    }
                    catch (Exception ex)
                    {
                        throw new DatabaseException("Insert", "Failed to add appointment to database.", ex);
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"Validation Error: {ex.Message}\nProperty: {ex.PropertyName}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DuplicateEntryException ex)
            {
                MessageBox.Show($"Duplicate Entry: {ex.Message}\nEntity: {ex.EntityName}\nValue: {ex.KeyValue}", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\nOperation: {ex.Operation}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveRec_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAppointments.SelectedRows.Count == 0)
                {
                    throw new ValidationException("Appointment", null, 
                        "Please select an appointment to remove.");
                }

                int appointmentId = (int?)dataGridViewAppointments.SelectedRows[0].Cells["AppointmentID"].Value ?? 0;

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to remove the appointment?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (var context = new HospitalContext())
                    {
                        try
                        {
                            var appointment = context.Appointments.Find(appointmentId);

                            if (appointment != null)
                            {
                                context.Appointments.Remove(appointment);
                                context.SaveChanges();

                                MessageBox.Show("Appointment removed successfully.");
                                LoadAppointmentsToGrid(null, null, null);
                                ClearForm();
                                Logger.LogInfo($"Appointment removed: ID {appointment.AppointmentID}");
                            }
                            else
                            {
                                throw new NotFoundException("Appointment", appointmentId, "Appointment not found.");
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new DatabaseException("Delete", "Failed to remove appointment from database.", ex);
                        }
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"Validation Error: {ex.Message}\nProperty: {ex.PropertyName}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show($"Not Found Error: {ex.Message}\nEntity: {ex.EntityName}\nValue: {ex.KeyValue}", "Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\nOperation: {ex.Operation}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRec_Click(object? sender, EventArgs e)
        {
            ClearForm();
            LoadAppointmentsToGrid(null, null, null); // Reload all appointments
            Logger.LogInfo("New appointment form cleared");
        }

        private void btnEditRec_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAppointmentID.Text) || dataGridViewAppointments.SelectedRows.Count == 0)
                {
                    throw new ValidationException("AppointmentID", txtAppointmentID.Text, "Please select an appointment to edit.");
                }

                if (!int.TryParse(txtAppointmentID.Text, out int appointmentId))
                {
                    throw new ValidationException("AppointmentID", txtAppointmentID.Text, "Invalid Appointment ID.");
                }

                if (cmbSelectPatient.SelectedItem == null || cmbAssignedTo.SelectedItem == null || cmbCreatedBy.SelectedItem == null)
                {
                    throw new ValidationException("RequiredFields", null, "Please fill out all required fields.");
                }

                int patientId = (int)cmbSelectPatient.SelectedValue;
                int doctorId = (int)cmbAssignedTo.SelectedValue;
                int receptionistId = (int)cmbCreatedBy.SelectedValue;
                int age = int.Parse(txtAge.Text);
                string gender = txtGender.Text;
                DateTime scheduledDate = dateTimePickerScheduled.Value;

                using (var context = new HospitalContext())
                {
                    try
                    {
                        var appointment = context.Appointments.Find(appointmentId);

                        if (appointment != null)
                        {
                            appointment.PatientID = patientId;
                            appointment.DoctorID = doctorId;
                            appointment.ReceptionistID = receptionistId;
                            appointment.Age = age;
                            appointment.Gender = gender;
                            appointment.ScheduledDate = scheduledDate;
                            context.SaveChanges();

                            MessageBox.Show("Appointment updated successfully!");
                            LoadAppointmentsToGrid(null, null, null);
                            ClearForm();
                            Logger.LogInfo($"Appointment updated: ID {appointment.AppointmentID} for patient {cmbSelectPatient.Text} with doctor {cmbAssignedTo.Text}");
                        }
                        else
                        {
                            throw new NotFoundException("Appointment", appointmentId, "Appointment not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new DatabaseException("Update", "Failed to update appointment in database.", ex);
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"Validation Error: {ex.Message}\nProperty: {ex.PropertyName}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show($"Not Found Error: {ex.Message}\nEntity: {ex.EntityName}\nValue: {ex.KeyValue}", "Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\nOperation: {ex.Operation}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScheduleAppointment_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cmbSelectPatient.SelectedValue == null || cmbAssignedTo.SelectedValue == null)
                {
                    throw new ValidationException("RequiredFields", new { Patient = cmbSelectPatient.SelectedValue, Doctor = cmbAssignedTo.SelectedValue }, 
                        "Please select both a patient and a doctor.");
                }

                DateTime appointmentDate = dateTimePickerScheduled.Value;
                int doctorId = (int)cmbAssignedTo.SelectedValue;
                int patientId = (int)cmbSelectPatient.SelectedValue;

                // Business rule: Cannot schedule appointments in the past
                if (appointmentDate < DateTime.Now)
                {
                    throw new BusinessRuleException("PastAppointment", 
                        "Cannot schedule appointments in the past.");
                }

                // Business rule: Check doctor's schedule
                using (var context = new HospitalContext())
                {
                    try
                    {
                        var existingAppointment = context.Appointments
                            .FirstOrDefault(a => a.DoctorID == doctorId && 
                                               a.ScheduledDate.Date == appointmentDate.Date);

                        if (existingAppointment != null)
                        {
                            throw new BusinessRuleException("DoctorSchedule", 
                                "Doctor already has an appointment scheduled for this date.");
                        }

                        // Create appointment
                        var appointment = new Appointment
                        {
                            PatientID = patientId,
                            DoctorID = doctorId,
                            ScheduledDate = appointmentDate,
                            CreatedAt = DateTime.Now,
                            Age = int.Parse(txtAge.Text),
                            Gender = txtGender.Text,
                            ReceptionistID = (int?)cmbCreatedBy.SelectedValue ?? 0
                        };

                        context.Appointments.Add(appointment);
                        context.SaveChanges();

                        MessageBox.Show("Appointment scheduled successfully!");
                        ClearForm();
                        LoadAppointmentsToGrid(null, null, null);
                    }
                    catch (Exception ex) when (ex is not BusinessRuleException && ex is not ValidationException && ex is not DuplicateEntryException)
                    {
                        throw new DatabaseException("Insert", 
                            $"Failed to schedule appointment: {ex.Message}");
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"Validation Error: {ex.Message}\nProperty: {ex.PropertyName}\nValue: {ex.AttemptedValue}", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (BusinessRuleException ex)
            {
                MessageBox.Show($"Business Rule Violation: {ex.Message}\nRule: {ex.RuleName}", 
                    "Business Rule Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\nOperation: {ex.Operation}", 
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelAppointment_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAppointments.SelectedRows.Count == 0)
                {
                    throw new ValidationException("Appointment", null, 
                        "Please select an appointment to cancel.");
                }

                int appointmentId = Convert.ToInt32(dataGridViewAppointments.SelectedRows[0].Cells["AppointmentID"].Value);
                DateTime appointmentDate = Convert.ToDateTime(dataGridViewAppointments.SelectedRows[0].Cells["ScheduledDate"].Value);

                // Business rule: Cannot cancel past appointments
                if (appointmentDate < DateTime.Now)
                {
                    throw new BusinessRuleException("PastAppointment", 
                        "Cannot cancel appointments that have already passed.");
                }

                var result = MessageBox.Show("Are you sure you want to cancel this appointment?",
                                   "Confirm Cancellation",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (var context = new HospitalContext())
                    {
                        try
                        {
                            var appointment = context.Appointments.Find(appointmentId);

                            if (appointment != null)
                            {
                                context.Appointments.Remove(appointment);
                                context.SaveChanges();

                                MessageBox.Show("Appointment cancelled successfully.");
                                LoadAppointmentsToGrid(null, null, null);
                            }
                            else
                            {
                                throw new NotFoundException("Appointment", appointmentId.ToString(), 
                                    "Appointment not found in database.");
                            }
                        }
                        catch (Exception ex) when (ex is not NotFoundException)
                        {
                            throw new DatabaseException("Delete", 
                                $"Failed to cancel appointment: {ex.Message}");
                        }
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"Validation Error: {ex.Message}\nProperty: {ex.PropertyName}", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (BusinessRuleException ex)
            {
                MessageBox.Show($"Business Rule Violation: {ex.Message}\nRule: {ex.RuleName}", 
                    "Business Rule Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show($"Not Found: {ex.Message}\nEntity: {ex.EntityName}\nID: {ex.KeyValue}", 
                    "Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\nOperation: {ex.Operation}", 
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterAppointments_Click(object? sender, EventArgs e)
        {
            int? doctorId = (int?)cmbFilterDoctor.SelectedValue;
            int? patientId = (int?)cmbFilterPatient.SelectedValue;
            DateTime? scheduledDate = dtpFilterDate.Value.Date;

            if (doctorId == 0) doctorId = null; // Treat "All Doctors" as no filter
            if (patientId == 0) patientId = null; // Treat "All Patients" as no filter

            LoadAppointmentsToGrid(doctorId, patientId, scheduledDate);
        }

        private void btnClearFilter_Click(object? sender, EventArgs e)
        {
            cmbFilterDoctor.SelectedIndex = 0; // Select "All Doctors"
            cmbFilterPatient.SelectedIndex = 0; // Select "All Patients"
            dtpFilterDate.Value = DateTime.Now; // Reset date to current
            LoadAppointmentsToGrid(null, null, null); // Load all appointments
        }
    }
}