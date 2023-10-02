using System;
using System.Collections.Generic;

namespace eGym2023.Services.DataDB;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int? CustomerId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? DueDate { get; set; }

    public string? PaymentStatus { get; set; }

    public virtual User? Customer { get; set; }
}
