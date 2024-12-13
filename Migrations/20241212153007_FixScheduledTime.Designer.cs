﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HilaryHairCareAPI.Migrations
{
    [DbContext(typeof(HilaryHaircareDbContext))]
    [Migration("20241212153007_FixScheduledTime")]
    partial class FixScheduledTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppointmentService", b =>
                {
                    b.Property<int>("AppointmentsId")
                        .HasColumnType("integer");

                    b.Property<int>("ServicesId")
                        .HasColumnType("integer");

                    b.HasKey("AppointmentsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("AppointmentService");

                    b.HasData(
                        new
                        {
                            AppointmentsId = 1,
                            ServicesId = 1
                        },
                        new
                        {
                            AppointmentsId = 1,
                            ServicesId = 3
                        },
                        new
                        {
                            AppointmentsId = 2,
                            ServicesId = 2
                        });
                });

            modelBuilder.Entity("HilaryHaircareAPI.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ScheduledTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("StylistId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            IsCancelled = false,
                            ScheduledTime = new DateTime(2024, 12, 12, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 1,
                            TotalCost = 40.00m
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            IsCancelled = true,
                            ScheduledTime = new DateTime(2024, 12, 13, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 2,
                            TotalCost = 75.00m
                        });
                });

            modelBuilder.Entity("HilaryHaircareAPI.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "emma@example.com",
                            FirstName = "Emma",
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 2,
                            Email = "liam@example.com",
                            FirstName = "Liam",
                            LastName = "Williams"
                        });
                });

            modelBuilder.Entity("HilaryHaircareAPI.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 25.00m,
                            Description = "Basic haircut",
                            Name = "Haircut"
                        },
                        new
                        {
                            Id = 2,
                            Cost = 75.00m,
                            Description = "Full hair coloring",
                            Name = "Coloring"
                        },
                        new
                        {
                            Id = 3,
                            Cost = 15.00m,
                            Description = "Beard shaping and trimming",
                            Name = "Beard Trim"
                        });
                });

            modelBuilder.Entity("HilaryHaircareAPI.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "alice@example.com",
                            FirstName = "Alice",
                            IsActive = true,
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bob@example.com",
                            FirstName = "Bob",
                            IsActive = true,
                            LastName = "Jones"
                        },
                        new
                        {
                            Id = 3,
                            Email = "charlie@example.com",
                            FirstName = "Charlie",
                            IsActive = false,
                            LastName = "Brown"
                        });
                });

            modelBuilder.Entity("AppointmentService", b =>
                {
                    b.HasOne("HilaryHaircareAPI.Models.Appointment", null)
                        .WithMany()
                        .HasForeignKey("AppointmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HilaryHaircareAPI.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HilaryHaircareAPI.Models.Appointment", b =>
                {
                    b.HasOne("HilaryHaircareAPI.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HilaryHaircareAPI.Models.Stylist", "Stylist")
                        .WithMany()
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });
#pragma warning restore 612, 618
        }
    }
}
