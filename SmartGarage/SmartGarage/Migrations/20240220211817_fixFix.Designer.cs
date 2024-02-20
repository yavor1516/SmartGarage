﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGarage;

#nullable disable

namespace SmartGarage.Migrations
{
    [DbContext(typeof(GarageContext))]
    [Migration("20240220211817_fixFix")]
    partial class fixFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarModel", b =>
                {
                    b.Property<int>("CarModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarModelID"), 1L, 1);

                    b.Property<int?>("ManufacturerID")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarModelID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.HasIndex("UserID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"), 1L, 1);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("UserID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"), 1L, 1);

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("UserID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("LinkedVehicles", b =>
                {
                    b.Property<int>("LinkedVehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkedVehicleID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceID")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("ManufacturerID")
                        .HasColumnType("int");

                    b.Property<int>("ModelID")
                        .HasColumnType("int");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("YearOfCreation")
                        .HasColumnType("int");

                    b.HasKey("LinkedVehicleID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("InvoiceID");

                    b.HasIndex("ManufacturerID");

                    b.HasIndex("ModelID");

                    b.ToTable("LinkedVehicles");
                });

            modelBuilder.Entity("Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManufacturerID"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManufacturerID");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"), 1L, 1);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ServiceID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("SmartGarage.Models.LinkedVehicleService", b =>
                {
                    b.Property<int>("LinkedVehicleServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkedVehicleServiceID"), 1L, 1);

                    b.Property<int?>("LinkedVehicleID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ServiceID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("LinkedVehicleServiceID");

                    b.HasIndex("LinkedVehicleID");

                    b.HasIndex("ServiceID");

                    b.ToTable("LinkedVehicleService");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("LastName")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("isBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("isOnline")
                        .HasColumnType("bit");

                    b.Property<string>("phoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UserID");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleID"), 1L, 1);

                    b.Property<int?>("CarModelID")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("int");

                    b.HasKey("VehicleID");

                    b.HasIndex("CarModelID");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarModel", b =>
                {
                    b.HasOne("Manufacturer", "Manufacturer")
                        .WithMany("CarModels")
                        .HasForeignKey("ManufacturerID");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Customer", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Invoice", b =>
                {
                    b.HasOne("Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Employee");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LinkedVehicles", b =>
                {
                    b.HasOne("Customer", "Customer")
                        .WithMany("LinkedVehicles")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Employee", "Employee")
                        .WithMany("LinkedVehiclesCreated")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Invoice", "Invoice")
                        .WithMany("LinkedVehicles")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Invoice");

                    b.Navigation("Manufacturer");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Service", b =>
                {
                    b.HasOne("Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SmartGarage.Models.LinkedVehicleService", b =>
                {
                    b.HasOne("LinkedVehicles", "LinkedVehicle")
                        .WithMany("LinkedVehicleServices")
                        .HasForeignKey("LinkedVehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinkedVehicle");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.HasOne("CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelID");

                    b.HasOne("Employee", "Employee")
                        .WithMany("VehiclesCreated")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.Navigation("CarModel");

                    b.Navigation("Employee");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Customer", b =>
                {
                    b.Navigation("LinkedVehicles");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Navigation("LinkedVehiclesCreated");

                    b.Navigation("VehiclesCreated");
                });

            modelBuilder.Entity("Invoice", b =>
                {
                    b.Navigation("LinkedVehicles");
                });

            modelBuilder.Entity("LinkedVehicles", b =>
                {
                    b.Navigation("LinkedVehicleServices");
                });

            modelBuilder.Entity("Manufacturer", b =>
                {
                    b.Navigation("CarModels");
                });
#pragma warning restore 612, 618
        }
    }
}
