using System;
using System.Collections.Generic;

namespace eGym2023.Services.DataDB;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? ServiceId { get; set; }

    public int? CustomerId { get; set; }

    public int? Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime? Date { get; set; }

    public virtual User? Customer { get; set; }

    public virtual Service? Service { get; set; }
}
