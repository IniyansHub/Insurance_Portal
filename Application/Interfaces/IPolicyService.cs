using Insurance_Portal.Domain.DTO;
using Insurance_Portal.Domain.Entities;

namespace Insurance_Portal.Application.Interfaces;

public interface IPolicyService
{
  public Task<PolicyResponseDTO> GetAllPolicy();
  public Task<PolicyResponseDTO> GetPolicyById(int policyId);
  public Task<PolicyResponseDTO> AddPolicy(Policy newPolicy);
  public Task<PolicyResponseDTO> UpdatePolicy(Policy updatedPolicy,int id);
  public Task<PolicyResponseDTO> DeletePolicy(int policyId);

}