using System;
using System.Collections.Generic;

namespace eGym2023.Services.DataDB;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? CustomerId { get; set; }

    public int? ScheduleId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? TransactionId { get; set; }

    public virtual User? Customer { get; set; }

    public virtual Schedule? Schedule { get; set; }
}
