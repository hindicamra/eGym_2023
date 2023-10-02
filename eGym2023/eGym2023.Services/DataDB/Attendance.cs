using System;
using System.Collections.Generic;

namespace eGym2023.Services.DataDB;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int? SessionId { get; set; }

    public int? CustomerId { get; set; }

    public string? Status { get; set; }

    public virtual User? Customer { get; set; }

    public virtual Session? Session { get; set; }
}
