using Insurance_Portal.Domain.Entities;

namespace Insurance_Portal.Application.Interfaces;
public interface IUserPolicyService
{
  public UserPolicyResponseDTO GetUserPolicies(string email);
  public UserPolicyResponseDTO AddUserPolicy(UserPolicy newUserPolicy);
  public UserPolicyResponseDTO UpdatePolicyStatus(int policyId, string status);
}