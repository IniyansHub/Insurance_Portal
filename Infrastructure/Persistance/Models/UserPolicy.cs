using System;
using System.Collections.Generic;

namespace Infrastructure.Persistance.Models;

public partial class UserPolicy
{
    public int RecordId { get; set; }

    public int PolicyId { get; set; }

    public string PolicyUserId { get; set; } = null!;

    public string PolicyStartDate { get; set; } = null!;

    public string PolicyEndDate { get; set; } = null!;

    public string? PolicyStatus { get; set; }

    public virtual Policy Policy { get; set; } = null!;

    public virtual UserDetail PolicyUser { get; set; } = null!;
}
