﻿// <auto-generated />
using System;
using Hospital_Management.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital_Management.Migrations
{
    [DbContext(typeof(HospitalContext))]
    partial class HospitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospital_Management.Core.Entities.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AdminID");

                    b.HasIndex("UserID");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            AdminID = 1,
                            FullName = "Arlind Krasniqi",
                            PhoneNumber = "0612345678",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<int>("ReceptionistID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScheduledDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.HasIndex("ReceptionistID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Bill", b =>
                {
                    b.Property<int>("BillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillID"));

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<string>("Services")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("BillID");

                    b.HasIndex("PatientID");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorID");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("AssignedDoctor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Receptionist", b =>
                {
                    b.Property<int>("ReceptionistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceptionistID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ReceptionistID");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Receptionists");

                    b.HasData(
                        new
                        {
                            ReceptionistID = 1,
                            FullName = "RoZaldo",
                            PhoneNumber = "0698765432",
                            UserID = 2
                        },
                        new
                        {
                            ReceptionistID = 2,
                            FullName = "Helena",
                            PhoneNumber = "0655555555",
                            UserID = 3
                        },
                        new
                        {
                            ReceptionistID = 3,
                            FullName = "Ina",
                            PhoneNumber = "0689078456",
                            UserID = 4
                        });
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceID = 1,
                            Category = "Consultation",
                            Description = "Standard doctor consultation",
                            Name = "General Consultation",
                            Price = 50.00m
                        },
                        new
                        {
                            ServiceID = 2,
                            Category = "Consultation",
                            Description = "Specialist doctor consultation",
                            Name = "Specialist Consultation",
                            Price = 100.00m
                        },
                        new
                        {
                            ServiceID = 3,
                            Category = "Laboratory",
                            Description = "Complete blood count",
                            Name = "Blood Test",
                            Price = 30.00m
                        },
                        new
                        {
                            ServiceID = 4,
                            Category = "Imaging",
                            Description = "Standard X-Ray imaging",
                            Name = "X-Ray",
                            Price = 80.00m
                        },
                        new
                        {
                            ServiceID = 5,
                            Category = "Imaging",
                            Description = "Magnetic Resonance Imaging",
                            Name = "MRI Scan",
                            Price = 300.00m
                        },
                        new
                        {
                            ServiceID = 6,
                            Category = "Diagnostic",
                            Description = "Electrocardiogram",
                            Name = "ECG",
                            Price = 60.00m
                        },
                        new
                        {
                            ServiceID = 7,
                            Category = "Imaging",
                            Description = "Ultrasound examination",
                            Name = "Ultrasound",
                            Price = 120.00m
                        },
                        new
                        {
                            ServiceID = 8,
                            Category = "Treatment",
                            Description = "Standard vaccination",
                            Name = "Vaccination",
                            Price = 40.00m
                        });
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            FullName = "Arlind Krasniqi",
                            Password = "UdveFgzgF8aPmz9H0Pjn73Jtmi+xbFms9WimaqP8ny4=",
                            PhoneNumber = "0612345678",
                            Role = "Admin",
                            Username = "Arlind"
                        },
                        new
                        {
                            UserID = 2,
                            FullName = "RoZaldo",
                            Password = "a4ayc/80/OGda4BO/1o/V0etpOqiLx1JwB5S3beHW0s=",
                            PhoneNumber = "0698765432",
                            Role = "Receptionist",
                            Username = "aldo"
                        },
                        new
                        {
                            UserID = 3,
                            FullName = "Helena",
                            Password = "cQR0GpLnPrbF1pzQTPCvvlCoeWoBDY+iXar3nl4XO/M=",
                            PhoneNumber = "0655555555",
                            Role = "Receptionist",
                            Username = "helena"
                        },
                        new
                        {
                            UserID = 4,
                            FullName = "Ina",
                            Password = "vKw3G1T1mUWhSqSeLkCOXW5NvFk4f12M/GsBXUDVuwI=",
                            PhoneNumber = "0689078456",
                            Role = "Receptionist",
                            Username = "ina"
                        });
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Admin", b =>
                {
                    b.HasOne("Hospital_Management.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Appointment", b =>
                {
                    b.HasOne("Hospital_Management.Core.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital_Management.Core.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital_Management.Core.Entities.Receptionist", "Receptionist")
                        .WithMany("Appointments")
                        .HasForeignKey("ReceptionistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Receptionist");
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Bill", b =>
                {
                    b.HasOne("Hospital_Management.Core.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Receptionist", b =>
                {
                    b.HasOne("Hospital_Management.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Hospital_Management.Core.Entities.Receptionist", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
