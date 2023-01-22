using System;
using System.Collections.Generic;

namespace Infrastructure.Persistance.Models;

public partial class AuthDetail
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public sbyte IsAdmin { get; set; }
}
