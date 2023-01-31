public class UserPolicyResponseDTO
{
  public int statusCode { get; set; }
  public string? message { get; set; }
  public List<UserPolicy>? userPolicies { get; set; }
}