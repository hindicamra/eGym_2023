using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace eGym2023.Services.DataDB;

public partial class EGymDbContext : DbContext
{
    public EGymDbContext()
    {
    }

    public EGymDbContext(DbContextOptions<EGymDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<MealPlan> MealPlans { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=eGymDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69263C6E4C5F18");

            entity.ToTable("Attendance");

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Customer).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Attendanc__Custo__4222D4EF");

            entity.HasOne(d => d.Session).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Attendanc__Sessi__412EB0B6");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoices__D796AAD54E97724C");

            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DueDate).HasColumnType("date");
            entity.Property(e => e.PaymentStatus).HasMaxLength(20);

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Invoices__Custom__44FF419A");
        });

        modelBuilder.Entity<MealPlan>(entity =>
        {
            entity.HasKey(e => e.MealPlanId).HasName("PK__MealPlan__0620DB56D4794C01");

            entity.Property(e => e.MealPlanId).HasColumnName("MealPlanID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.MealPlanDescription).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.MealPlans)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__MealPlans__Custo__32E0915F");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A589A639F6D");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("TransactionID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Payments__Custom__398D8EEE");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("FK__Payments__Schedu__3A81B327");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AED5468990");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Reviews__Custome__36B12243");

            entity.HasOne(d => d.Service).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Reviews__Service__35BCFE0A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A478F025C");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(20);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B69FF62B9D2");

            entity.ToTable("Schedule");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TrainerId).HasColumnName("TrainerID");

            entity.HasOne(d => d.Customer).WithMany(p => p.ScheduleCustomers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Schedule__Custom__300424B4");

            entity.HasOne(d => d.Service).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Schedule__Servic__2E1BDC42");

            entity.HasOne(d => d.Trainer).WithMany(p => p.ScheduleTrainers)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__Schedule__Traine__2F10007B");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__C51BB0EA7B354494");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceName).HasMaxLength(100);
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Sessions__C9F49270EA5737E1");

            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.TrainerId).HasColumnName("TrainerID");

            entity.HasOne(d => d.Service).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Sessions__Servic__3E52440B");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__Sessions__Traine__3D5E1FD2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACE68CA240");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PasswordSalt).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A35D7C7AB58");

            entity.Property(e => e.UserRolesUserId).HasColumnName("UserRolesUserID");
            entity.Property(e => e.UserRolesUserIdroleId).HasColumnName("UserRolesUserIDRoleID");

            entity.HasOne(d => d.UserRolesUser).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserRolesUserId)
                .HasConstraintName("FK__UserRoles__UserR__286302EC");

            entity.HasOne(d => d.UserRolesUserIdrole).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserRolesUserIdroleId)
                .HasConstraintName("FK__UserRoles__UserR__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
