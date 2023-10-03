using System;
using System.Collections.Generic;

namespace eGym2023.Services.DataDB;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<MealPlan> MealPlans { get; set; } = new List<MealPlan>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual UserRole? Role { get; set; }

    public virtual ICollection<Schedule> ScheduleCustomers { get; set; } = new List<Schedule>();

    public virtual ICollection<Schedule> ScheduleTrainers { get; set; } = new List<Schedule>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
