using Insurance_Portal.Domain.Entities;

namespace Insurance_Portal.Application.Interfaces;
public interface IPolicyRepository
{
  public Task<List<Policy>> GetAllPolicy();
  public Task<Policy> GetPolicyById(int id);
  public Task<Policy> AddPolicy(Policy newPolicy);
  public Task<Policy> UpdatePolicy(Policy updatedPolicy, int id);
  public Task<Policy> DeletePolicy(int id);
}