using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Domain.Entities;
using Insurance_Portal.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class AuthRepository : IAuthRepository
{

  private readonly InsuranceDBContext _insuranceDB;

  public AuthRepository(InsuranceDBContext insuranceDB)
  {
    _insuranceDB = insuranceDB;
  }

  public async void AddUser(AuthDetail authDetail)
  {
    await _insuranceDB.AddAsync(authDetail);
    await _insuranceDB.SaveChangesAsync();
  }

  public async Task<AuthDetail> FindUser(string email)
  {
    return await _insuranceDB.AuthDetails.FirstOrDefaultAsync(x => x.Email == email);
  }

}