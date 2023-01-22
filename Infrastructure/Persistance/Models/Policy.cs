using System;
using System.Collections.Generic;

namespace Infrastructure.Persistance.Models;

public partial class Policy
{
    public int PolicyId { get; set; }

    public string PolicyName { get; set; } = null!;

    public string PolicyType { get; set; } = null!;

    public sbyte PolicyValidity { get; set; }

    public double PolicyPrice { get; set; }

    public string? PolicyDescription { get; set; }

    public virtual ICollection<UserPolicy> UserPolicies { get; } = new List<UserPolicy>();
}
