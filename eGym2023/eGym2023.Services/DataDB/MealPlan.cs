using System;
using System.Collections.Generic;

namespace eGym2023.Services.DataDB;

public partial class MealPlan
{
    public int MealPlanId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? Date { get; set; }

    public string? MealPlanDescription { get; set; }

    public virtual User? Customer { get; set; }
}
