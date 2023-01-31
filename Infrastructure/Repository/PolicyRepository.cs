using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Domain.Entities;
using Insurance_Portal.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PolicyRepository : IPolicyRepository
{

  private readonly InsuranceDBContext _insuranceDB;

  public PolicyRepository(InsuranceDBContext insuranceDB)
  {
    _insuranceDB = insuranceDB;
  }

  public async Task<Policy> AddPolicy(Policy newPolicy)
  {
    try
    {
      await _insuranceDB.Policies.AddAsync(newPolicy);
      await _insuranceDB.SaveChangesAsync();
      return newPolicy;
    }
    catch (Exception)
    {
      return null;
    }

  }

  public async Task<Policy> DeletePolicy(int id)
  {
    Policy policy = await _insuranceDB.Policies.FirstOrDefaultAsync(x => x.PolicyId == id);
    if (policy != null)
    {
      _insuranceDB.Remove(policy);
      await _insuranceDB.SaveChangesAsync();
      return policy;
    }
    else
    {
      return policy;
    }
  }

  public async Task<List<Policy>> GetAllPolicy()
  {
    return await _insuranceDB.Policies.ToListAsync();
  }

  public async Task<Policy> GetPolicyById(int id)
  {
    return await _insuranceDB.Policies.FirstOrDefaultAsync(x => x.PolicyId == id);
  }

  public async Task<Policy> UpdatePolicy(Policy updatedPolicy, int id)
  {

    Policy policy = await _insuranceDB.Policies.FirstOrDefaultAsync(x => x.PolicyId == id);
    if (policy != null)
    {
      try
      {
        policy.PolicyName = updatedPolicy.PolicyName;
        policy.PolicyPrice = updatedPolicy.PolicyPrice;
        policy.PolicyType = updatedPolicy.PolicyType;
        policy.PolicyValidity = updatedPolicy.PolicyValidity;
        policy.PolicyDescription = updatedPolicy.PolicyDescription;
        await _insuranceDB.SaveChangesAsync();
        return policy;
      }
      catch (Exception)
      {
        return null;
      }
    }
    else
    {
      return policy;
    }
  }
}