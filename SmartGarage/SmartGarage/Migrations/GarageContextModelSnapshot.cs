﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGarage;

#nullable disable

namespace SmartGarage.Migrations
{
    [DbContext(typeof(GarageContext))]
    partial class GarageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("LinkedVehiclelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkedVehiclelID"), 1L, 1);

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int?>("VehicleID")
                        .HasColumnType("int");

                    b.Property<int>("YearOfCreation")
                        .HasColumnType("int");

                    b.HasKey("LinkedVehiclelID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("VehicleID");

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
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<int?>("LinkedVehiclesLinkedVehiclelID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ServiceId");

                    b.HasIndex("LinkedVehiclesLinkedVehiclelID");

                    b.ToTable("Services");
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
                        .HasForeignKey("CustomerID");

                    b.HasOne("Employee", "Employee")
                        .WithMany("LinkedVehiclesCreated")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("Invoice", null)
                        .WithMany("LinkedVehicles")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleID");

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Service", b =>
                {
                    b.HasOne("LinkedVehicles", null)
                        .WithMany("Survices")
                        .HasForeignKey("LinkedVehiclesLinkedVehiclelID");
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
                    b.Navigation("Survices");
                });

            modelBuilder.Entity("Manufacturer", b =>
                {
                    b.Navigation("CarModels");
                });
#pragma warning restore 612, 618
        }
    }
}
