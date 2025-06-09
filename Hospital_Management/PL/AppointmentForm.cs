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

namespace Hospital_Management.PL
{
    public partial class AppointmentForm : Form
    {
        private int originalPatientID;
        public AppointmentForm()
        {
            InitializeComponent();
            cmbSelectPatient.SelectedIndexChanged += cmbSelectPatient_SelectedIndexChanged;
            dataGridViewAppointments.CellClick += dataGridViewAppointments_CellClick;
            cmbCreatedBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignedTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadPatientsIntoComboBox();
            LoadReceptionistsIntoComboBox();
            LoadAppointmentsToGrid();
            LoadDoctorsIntoComboBox();
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
        private void LoadAppointmentsToGrid()
        {
            using (var context = new HospitalContext())
            {
                var appointments = context.Appointments
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor)
                    .Include(a => a.Receptionist)
                    .Select(a => new
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
        }
        private void btnAddRec_Click(object? sender, EventArgs e)
        {
            if (cmbSelectPatient.SelectedItem == null)
            {
                MessageBox.Show("Please select a patient!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(txtGender.Text))
            {
                MessageBox.Show("Please fill in age and gender!");
                return;
            }

            if (cmbAssignedTo.SelectedItem == null)
            {
                MessageBox.Show("Please assign a doctor!");
                return;
            }

            if (cmbCreatedBy.SelectedItem == null)
            {
                MessageBox.Show("Please select the receptionist who will create the appointment!");
                return;
            }

            using (var context = new HospitalContext())
            {
                int selectedPatientId = (int?)cmbSelectPatient.SelectedValue ?? 0;
                DateTime selectedDate = dateTimePickerScheduled.Value.Date;

                bool appointmentExists = context.Appointments
                    .Any(a => a.PatientID == selectedPatientId && a.ScheduledDate.Date == selectedDate);

                if (appointmentExists)
                {
                    MessageBox.Show("An appointment for this patient is already added on this date.", "Duplicate Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
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
                context.Appointments.Add(appointment);
                context.SaveChanges();
                MessageBox.Show("Appointment successfully added!");
                LoadAppointmentsToGrid();
                ClearForm();
            }
        }

        private void btnRemoveRec_Click(object? sender, EventArgs e)
        {
            if (dataGridViewAppointments.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to remove the appointment?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int appointmentId = (int?)dataGridViewAppointments.SelectedRows[0].Cells["AppointmentID"].Value ?? 0;

                    using (var context = new HospitalContext())
                    {
                        var appointment = context.Appointments.Find(appointmentId);

                        if (appointment != null)
                        {
                            context.Appointments.Remove(appointment);
                            context.SaveChanges();

                            MessageBox.Show("Appointment removed successfully.");
                            LoadAppointmentsToGrid();
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Appointment not found.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to remove.");
            }
        }

        private void btnNewRec_Click(object? sender, EventArgs e)
        {
            cmbSelectPatient.SelectedIndex = -1;
            cmbAssignedTo.SelectedIndex = -1;
            cmbCreatedBy.SelectedIndex = -1;

            txtAge.Clear();
            txtGender.Clear();

            dateTimePickerScheduled.Value = DateTime.Now;

            cmbSelectPatient.Focus();
        }

        private void btnEditRec_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAppointments.SelectedRows.Count > 0)
                {
                    int appointmentId = (int?)dataGridViewAppointments.SelectedRows[0].Cells["AppointmentID"].Value ?? 0;
                    using (var context = new HospitalContext())
                    {
                        var appointment = context.Appointments.Find(appointmentId);
                        if (appointment != null)
                        {
                            if (cmbSelectPatient.SelectedValue != null)
                            {
                                appointment.PatientID = (int?)cmbSelectPatient.SelectedValue ?? 0;
                            }
                            if (cmbAssignedTo.SelectedValue != null)
                            {
                                appointment.DoctorID = (int?)cmbAssignedTo.SelectedValue ?? 0;
                            }
                            appointment.Age = int.Parse(txtAge.Text);
                            appointment.Gender = txtGender.Text;
                            if (cmbCreatedBy.SelectedValue != null)
                            {
                                appointment.ReceptionistID = (int?)cmbCreatedBy.SelectedValue ?? 0;
                            }
                            appointment.ScheduledDate = dateTimePickerScheduled.Value;

                            context.SaveChanges();
                            MessageBox.Show("Appointment successfully updated!");
                            LoadAppointmentsToGrid();
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Appointment not found in database.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an appointment to edit.", "No Appointment Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            DoctorID = doctorId,
                            PatientID = patientId,
                            ScheduledDate = appointmentDate,
                            CreatedAt = DateTime.Now,
                            // ... other properties
                        };

                        context.Appointments.Add(appointment);
                        context.SaveChanges();

                        MessageBox.Show("Appointment scheduled successfully!");
                        ClearForm();
                        LoadAppointmentsToGrid();
                    }
                    catch (Exception ex) when (ex is not BusinessRuleException)
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
                                LoadAppointmentsToGrid();
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
    }
}