namespace Insurance_Portal.Domain.DTO;
public class AuthResponseDTO
{
  public int statusCode { get; set; }
  public string message { get; set; } = null!;
  public string? token { get; set; }

}