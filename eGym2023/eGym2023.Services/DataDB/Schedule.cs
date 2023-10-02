using System;
using System.Collections.Generic;

namespace eGym2023.Services.DataDB;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int? ServiceId { get; set; }

    public int? TrainerId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? TimeSlot { get; set; }

    public string? Status { get; set; }

    public virtual User? Customer { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Service? Service { get; set; }

    public virtual User? Trainer { get; set; }
}
