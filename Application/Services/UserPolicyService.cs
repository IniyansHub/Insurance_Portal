using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Domain.Entities;

namespace Insurance_portal.Application.Services;

public class UserPolicyService : IUserPolicyService
{

  private readonly IUserPolicyRepository _userPolicyRepo;

  public UserPolicyService(IUserPolicyRepository userPolicyRepo)
  {
    _userPolicyRepo = userPolicyRepo;
  }

  public UserPolicyResponseDTO AddUserPolicy(UserPolicy newUserPolicy)
  {
    throw new NotImplementedException();
  }

  public UserPolicyResponseDTO GetUserPolicies(string email)
  {
    var userPolicy = _userPolicyRepo.GetAllUserPolicy(email);
    var response = new UserPolicyResponseDTO();
    if (userPolicy != null)
    {
      response.statusCode = 200;
      response.message = "Policies of the user " + email + " fetched successfully!";
      response.userPolicies = userPolicy;
      return response;
    }
    else
    {
      response.statusCode = 400;
      response.message = "Unable to fetch the details";
      response.userPolicies = null;
      return response;
    }
  }

  public UserPolicyResponseDTO UpdatePolicyStatus(int policyId, string status)
  {
    throw new NotImplementedException();
  }
}