namespace Insurance_Portal.Domain.DTO;
public class PolicyResponseDTO
{
  public int statusCode { get; set; }
  public string message { get; set; } = null!;
  public List<Policy>? Policies { get; set; } = new List<Policy>();

}