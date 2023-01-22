using System;
using System.Collections.Generic;

namespace Infrastructure.Persistance.Models;

public partial class UserDetail
{
    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public long MobileNumber { get; set; }

    public string Dob { get; set; } = null!;

    public virtual ICollection<UserPolicy> UserPolicies { get; } = new List<UserPolicy>();
}
