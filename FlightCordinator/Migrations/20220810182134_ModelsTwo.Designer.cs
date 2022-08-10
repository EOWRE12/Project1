﻿// <auto-generated />
using System;
using FlightCordinator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightCordinator.Migrations
{
    [DbContext(typeof(FCContext))]
    [Migration("20220810182134_ModelsTwo")]
    partial class ModelsTwo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlightCordinator.Models.Airport", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AirportId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirportId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("FlightCordinator.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"), 1L, 1);

                    b.Property<int>("ArrivalAirportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartureAirportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightId");

                    b.HasIndex("ArrivalAirportId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightCordinator.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("PassengerId");

                    b.HasIndex("FlightId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("FlightCordinator.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"), 1L, 1);

                    b.Property<int>("ArrivalAirportId")
                        .HasColumnType("int");

                    b.Property<int>("DepartureAirportId")
                        .HasColumnType("int");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.HasIndex("ArrivalAirportId");

                    b.HasIndex("FlightId");

                    b.HasIndex("PassengerId")
                        .IsUnique();

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("FlightCordinator.Models.Flight", b =>
                {
                    b.HasOne("FlightCordinator.Models.Airport", null)
                        .WithMany("Flights")
                        .HasForeignKey("ArrivalAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightCordinator.Models.Passenger", b =>
                {
                    b.HasOne("FlightCordinator.Models.Flight", null)
                        .WithMany("Passengers")
                        .HasForeignKey("FlightId");
                });

            modelBuilder.Entity("FlightCordinator.Models.Ticket", b =>
                {
                    b.HasOne("FlightCordinator.Models.Airport", null)
                        .WithMany("Tickets")
                        .HasForeignKey("ArrivalAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightCordinator.Models.Flight", null)
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightCordinator.Models.Passenger", "Passenger")
                        .WithOne("Ticket")
                        .HasForeignKey("FlightCordinator.Models.Ticket", "PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("FlightCordinator.Models.Airport", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("FlightCordinator.Models.Flight", b =>
                {
                    b.Navigation("Passengers");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("FlightCordinator.Models.Passenger", b =>
                {
                    b.Navigation("Ticket")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
