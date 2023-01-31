using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Domain.Entities;
using Insurance_Portal.Infrastructure.Persistance;

namespace Insurance_Portal.Infrastructure.Repository;
public class UserPolicyRepository : IUserPolicyRepository
{

  private readonly InsuranceDBContext _insuranceDB;

  public UserPolicyRepository(InsuranceDBContext insuranceDB)
  {
    _insuranceDB = insuranceDB;
  }

  public UserPolicy AddUserPolicy(UserPolicy userPolicy)
  {
    try
    {
      _insuranceDB.UserPolicies.Add(userPolicy);
      _insuranceDB.SaveChanges();
      return userPolicy;
    }
    catch (Exception)
    {
      return null;
    }

  }

  public List<UserPolicy> GetAllUserPolicy(string email)
  {
    var query = from up in _insuranceDB.UserPolicies
                join p in _insuranceDB.Policies on up.PolicyId equals p.PolicyId
                join ud in _insuranceDB.UserDetails on up.PolicyUserId equals ud.Email
                where up.PolicyUserId == email
                select new UserPolicy
                {
                  RecordId = up.RecordId,
                  PolicyId = up.PolicyId,
                  PolicyUserId = up.PolicyUserId,
                  PolicyStartDate = up.PolicyStartDate,
                  PolicyEndDate = up.PolicyEndDate,
                  PolicyStatus = up.PolicyStatus,
                  Policy = p,
                  PolicyUser = ud
                };
    var result = query.OfType<UserPolicy>().ToList();
    return result;
  }

  public UserPolicy UpdatePolicyStatus(int policyId, string status)
  {
    var userPolicy = _insuranceDB.UserPolicies.FirstOrDefault(x => x.PolicyId == policyId);
    if (userPolicy != null)
    {
      userPolicy.PolicyStatus = status;
      _insuranceDB.SaveChanges();
      return userPolicy;
    }
    else
    {
      return null;
    }

  }
}