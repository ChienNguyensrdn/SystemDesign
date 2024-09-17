using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UberSystem.Domain.Entities;
namespace UberSystem.Infrastructure;


public partial class UberSystemDbContext : DbContext
{
    public UberSystemDbContext()
    {
    }

    public UberSystemDbContext(DbContextOptions<UberSystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cab> Cabs { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();
        return configuration.GetConnectionString("Default") ?? string.Empty;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cab>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cabs");

            entity.ToTable("cabs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DriverId).HasColumnName("driverId");
            entity.Property(e => e.RegNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regNo");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");

            entity.HasOne(d => d.Driver).WithMany(p => p.Cabs)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Cab_Driver");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Customers");

            entity.ToTable("customers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("createAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Customer_User");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Drivers");

            entity.ToTable("drivers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CabId).HasColumnName("cabId");
            entity.Property(e => e.CreateAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("createAt");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.LocationLatitude).HasColumnName("locationLatitude");
            entity.Property(e => e.LocationLongitude).HasColumnName("locationLongitude");
            entity.Property(e => e.UserId).HasColumnName("userId ");

            entity.HasOne(d => d.Cab).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.CabId)
                .HasConstraintName("FK_Driver_Cab");

            entity.HasOne(d => d.User).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Driver_User");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Payments");

            entity.ToTable("payments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreateAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("createAt");
            entity.Property(e => e.Method)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("method");
            entity.Property(e => e.TripId).HasColumnName("tripId");

            entity.HasOne(d => d.Trip).WithMany(p => p.Payments)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK_Payment_Trip");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ratings");

            entity.ToTable("ratings");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.DriverId).HasColumnName("driverId");
            entity.Property(e => e.Feedback)
                .HasMaxLength(1)
                .HasColumnName("feedback");
            entity.Property(e => e.Rating1).HasColumnName("rating");
            entity.Property(e => e.TripId).HasColumnName("tripId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Rating_Customer");

            entity.HasOne(d => d.Driver).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK_Rating_Driver");

            entity.HasOne(d => d.Trip).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK_Rating_Trip");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Trips");

            entity.ToTable("trips");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("createAt");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.DestinationLatitude).HasColumnName("destinationLatitude");
            entity.Property(e => e.DestinationLongitude).HasColumnName("destinationLongitude");
            entity.Property(e => e.DriverId).HasColumnName("driverId");
            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.SourceLatitude).HasColumnName("sourceLatitude");
            entity.Property(e => e.SourceLongitude).HasColumnName("sourceLongitude");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");

            entity.HasOne(d => d.Customer).WithMany(p => p.Trips)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Trip_Customer");

            entity.HasOne(d => d.Driver).WithMany(p => p.Trips)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK_Trip_Driver");

            entity.HasOne(d => d.Payment).WithMany(p => p.Trips)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Trip_Payment");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
