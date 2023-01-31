namespace Insurance_Portal.Domain.DTO;
public class UserDetailResponseDTO
{
  public int statusCode { get; set; }
  public string? message { get; set; }
  public UserDetail? userDetail { get; set; }
}