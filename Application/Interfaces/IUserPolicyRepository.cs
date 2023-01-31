using Insurance_Portal.Domain.Entities;

namespace Insurance_Portal.Application.Interfaces;
public interface IUserPolicyRepository
{
  public List<UserPolicy> GetAllUserPolicy(string email);
  public UserPolicy AddUserPolicy(UserPolicy userPolicy);
  public UserPolicy UpdatePolicyStatus(int policyId, string status);
}