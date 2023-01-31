using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Domain.Entities;
using Insurance_Portal.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Insurance_Portal.Infrastructure.Repository;

public class UserDetailRepository : IUserDetailRepository
{

  private readonly InsuranceDBContext _insuranceDB;

  public UserDetailRepository(InsuranceDBContext insuranceDB)
  {
    _insuranceDB = insuranceDB;
  }

  public async Task<UserDetail> CreateUserDetail(UserDetail userDetail)
  {
    try
    {
      await _insuranceDB.UserDetails.AddAsync(userDetail);
      await _insuranceDB.SaveChangesAsync();
      return userDetail;
    }
    catch (Exception)
    {
      return null;
    }
  }

  public async Task<UserDetail> GetUserDetail(string email)
  {
    return await _insuranceDB.UserDetails.FirstOrDefaultAsync(x => x.Email == email);
  }

  public async Task<UserDetail> UpdateUserDetail(UserDetail userDetail)
  {
    var userFound = await _insuranceDB.UserDetails.FirstOrDefaultAsync(x => x.Email == userDetail.Email);
    if (userFound != null)
    {
      userFound.FirstName = userDetail.FirstName;
      userFound.LastName = userDetail.LastName;
      userFound.MobileNumber = userDetail.MobileNumber;
      userFound.Dob = userDetail.Dob;
      userFound.Address = userDetail.Address;
      await _insuranceDB.SaveChangesAsync();
      return userFound;
    }
    else
    {
      return null;
    }
  }
}