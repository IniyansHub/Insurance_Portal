using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Domain.DTO;
using Insurance_Portal.Domain.Entities;

namespace Insurance_portal.Application.Services;
public class PolicyService : IPolicyService
{

  private readonly IPolicyRepository _policyRepository;

  public PolicyService(IPolicyRepository policyRepository)
  {
    _policyRepository = policyRepository;
  }

  public async Task<PolicyResponseDTO> AddPolicy(Policy newPolicy)
  {
    Policy policy = await _policyRepository.AddPolicy(newPolicy);
    var response = new PolicyResponseDTO();
    if (policy != null)
    {
      response.statusCode = 200;
      response.message = "Policies creation successful!";
      response.Policies?.Add(newPolicy);
      return response;
    }
    else
    {
      response.statusCode = 400;
      response.message = "Unable to create a new policy";
      response.Policies = null;
      return response;
    }
  }

  public async Task<PolicyResponseDTO> DeletePolicy(int policyId)
  {
    Policy policy = await _policyRepository.DeletePolicy(policyId);
    var response = new PolicyResponseDTO();
    if (policy != null)
    {
      response.statusCode = 200;
      response.message = "Policy deleted successfully!";
      response.Policies?.Add(policy);
      return response;
    }
    else
    {
      response.statusCode = 400;
      response.message = "Unable to delete the policy with this Id " + policyId + ".  Try checking whether the policy with this Id exist or not";
      response.Policies = null;
      return response;
    }
  }

  public async Task<PolicyResponseDTO> GetAllPolicy()
  {
    List<Policy> Policies = await _policyRepository.GetAllPolicy();
    var response = new PolicyResponseDTO();
    if (Policies != null)
    {
      response.statusCode = 200;
      response.message = "Policies fetched successfully!";
      response.Policies = Policies;
      return response;
    }
    else
    {
      response.statusCode = 404;
      response.message = "No Policies found";
      response.Policies = null;
      return response;
    }
  }

  public async Task<PolicyResponseDTO> GetPolicyById(int policyId)
  {
    Policy policy = await _policyRepository.GetPolicyById(policyId);
    var response = new PolicyResponseDTO();
    if (policy != null)
    {
      response.statusCode = 200;
      response.message = "Policies fetched successfully!";
      response.Policies?.Add(policy);
      return response;
    }
    else
    {
      response.statusCode = 404;
      response.message = "No Policy found with this Id";
      response.Policies = null;
      return response;
    }
  }

  public async Task<PolicyResponseDTO> UpdatePolicy(Policy updatedPolicy, int id)
  {
    Policy policy = await _policyRepository.UpdatePolicy(updatedPolicy, id);
    var response = new PolicyResponseDTO();
    if (policy != null)
    {
      response.statusCode = 200;
      response.message = "Policy updated successfully!";
      response.Policies?.Add(updatedPolicy);
      return response;
    }
    else
    {
      response.statusCode = 400;
      response.message = "Unable to update your existing policy";
      response.Policies = null;
      return response;
    }
  }
}