using System;
using System.Collections.Generic;

namespace eGym2023.Services.DataDB;

public partial class Session
{
    public int SessionId { get; set; }

    public int? TrainerId { get; set; }

    public int? ServiceId { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? TimeSlot { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Service? Service { get; set; }

    public virtual User? Trainer { get; set; }
}
