namespace Insurance_Portal.Domain.Entities;
public partial class AuthDetail
{
  public string Email { get; set; } = null!;

  public string Password { get; set; } = null!;

  public sbyte IsAdmin { get; set; }
}
