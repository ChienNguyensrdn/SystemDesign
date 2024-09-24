﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UberSystem.Infrastructure;

#nullable disable

namespace UberSystem.Infrastructure.Migrations
{
    [DbContext(typeof(UberSystemDbContext))]
    [Migration("20240924040511_ChangeColumnName")]
    partial class ChangeColumnName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UberSystem.Domain.Entities.Cab", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long?>("DriverId")
                        .HasColumnType("bigint")
                        .HasColumnName("driverId");

                    b.Property<string>("RegNo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("regNo");

                    b.Property<string>("Type")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("type")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PK_Cabs");

                    b.HasIndex("DriverId");

                    b.ToTable("cabs", (string)null);
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreateAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("createAt");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("userId");

                    b.HasKey("Id")
                        .HasName("PK_Customers");

                    b.HasIndex("UserId");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Driver", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long?>("CabId")
                        .HasColumnType("bigint")
                        .HasColumnName("cabId");

                    b.Property<byte[]>("CreateAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("createAt");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("dob");

                    b.Property<double?>("LocationLatitude")
                        .HasColumnType("float")
                        .HasColumnName("locationLatitude");

                    b.Property<double?>("LocationLongitude")
                        .HasColumnType("float")
                        .HasColumnName("locationLongitude");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("userId ");

                    b.HasKey("Id")
                        .HasName("PK_Drivers");

                    b.HasIndex("CabId");

                    b.HasIndex("UserId");

                    b.ToTable("drivers", (string)null);
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Payment", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<double?>("Amount")
                        .HasColumnType("float")
                        .HasColumnName("amount");

                    b.Property<byte[]>("CreateAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("createAt");

                    b.Property<string>("Method")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("method")
                        .IsFixedLength();

                    b.Property<long?>("TripId")
                        .HasColumnType("bigint")
                        .HasColumnName("tripId");

                    b.HasKey("Id")
                        .HasName("PK_Payments");

                    b.HasIndex("TripId");

                    b.ToTable("payments", (string)null);
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Rating", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint")
                        .HasColumnName("customerId");

                    b.Property<long?>("DriverId")
                        .HasColumnType("bigint")
                        .HasColumnName("driverId");

                    b.Property<string>("Feedback")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("feedback");

                    b.Property<int?>("Rating1")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<long?>("TripId")
                        .HasColumnType("bigint")
                        .HasColumnName("tripId");

                    b.HasKey("Id")
                        .HasName("PK_Ratings");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId");

                    b.HasIndex("TripId");

                    b.ToTable("ratings", (string)null);
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Trip", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<byte[]>("CreateAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("createAt");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint")
                        .HasColumnName("customerId");

                    b.Property<double?>("DestinationLatitude")
                        .HasColumnType("float")
                        .HasColumnName("destinationLatitude");

                    b.Property<double?>("DestinationLongitude")
                        .HasColumnType("float")
                        .HasColumnName("destinationLongitude");

                    b.Property<long?>("DriverId")
                        .HasColumnType("bigint")
                        .HasColumnName("driverId");

                    b.Property<long?>("PaymentId")
                        .HasColumnType("bigint")
                        .HasColumnName("paymentId");

                    b.Property<double?>("SourceLatitude")
                        .HasColumnType("float")
                        .HasColumnName("sourceLatitude");

                    b.Property<double?>("SourceLongitude")
                        .HasColumnType("float")
                        .HasColumnName("sourceLongitude");

                    b.Property<string>("Status")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("status")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PK_Trips");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId");

                    b.HasIndex("PaymentId");

                    b.ToTable("trips", (string)null);
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("EmailVerificationToken")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("emailVerifiedToken");

                    b.Property<bool>("EmailVerified")
                        .HasColumnType("bit")
                        .HasColumnName("emailVerified");

                    b.Property<string>("Password")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("password");

                    b.Property<int?>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.HasKey("Id")
                        .HasName("PK_Users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Cab", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.Driver", "Driver")
                        .WithMany("Cabs")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Cab_Driver");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Customer", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.User", "User")
                        .WithMany("Customers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Customer_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Driver", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.Cab", "Cab")
                        .WithMany("Drivers")
                        .HasForeignKey("CabId")
                        .HasConstraintName("FK_Driver_Cab");

                    b.HasOne("UberSystem.Domain.Entities.User", "User")
                        .WithMany("Drivers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Driver_User");

                    b.Navigation("Cab");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Payment", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.Trip", "Trip")
                        .WithMany("Payments")
                        .HasForeignKey("TripId")
                        .HasConstraintName("FK_Payment_Trip");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Rating", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.Customer", "Customer")
                        .WithMany("Ratings")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Rating_Customer");

                    b.HasOne("UberSystem.Domain.Entities.Driver", "Driver")
                        .WithMany("Ratings")
                        .HasForeignKey("DriverId")
                        .HasConstraintName("FK_Rating_Driver");

                    b.HasOne("UberSystem.Domain.Entities.Trip", "Trip")
                        .WithMany("Ratings")
                        .HasForeignKey("TripId")
                        .HasConstraintName("FK_Rating_Trip");

                    b.Navigation("Customer");

                    b.Navigation("Driver");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Trip", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.Customer", "Customer")
                        .WithMany("Trips")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Trip_Customer");

                    b.HasOne("UberSystem.Domain.Entities.Driver", "Driver")
                        .WithMany("Trips")
                        .HasForeignKey("DriverId")
                        .HasConstraintName("FK_Trip_Driver");

                    b.HasOne("UberSystem.Domain.Entities.Payment", "Payment")
                        .WithMany("Trips")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK_Trip_Payment");

                    b.Navigation("Customer");

                    b.Navigation("Driver");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Cab", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Driver", b =>
                {
                    b.Navigation("Cabs");

                    b.Navigation("Ratings");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Payment", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Trip", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.User", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Drivers");
                });
#pragma warning restore 612, 618
        }
    }
}
