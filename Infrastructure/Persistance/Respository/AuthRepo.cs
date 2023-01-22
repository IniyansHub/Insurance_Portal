using Infrastructure.Persistance;
using Infrastructure.Persistance.Models;
using Insurance_Portal.Application.Interfaces;
namespace Insurance_Portal.Infrastructure.Persistance.Respository;

public class AuthRepo : IAuthRepository
{

  private readonly InsuranceDbContext _insuranceDB;
  public AuthRepo(InsuranceDbContext insuranceDb)
  {
    _insuranceDB = insuranceDb;
  }

  public void AddUser(dynamic entity)
  {
    //Console.WriteLine(entity.GetType().GetProperty("Email").GetValue(entity,null));
    //Console.WriteLine(entity.GetType().GetProperty("Password").GetValue(entity,null));
    try
    {
      AuthDetail authDetail = new AuthDetail();
      authDetail.Email = entity.GetType().GetProperty("Email").GetValue(entity,null);
      authDetail.Password = entity.GetType().GetProperty("Password").GetValue(entity,null);
      _insuranceDB.AuthDetails.Add(authDetail);
      _insuranceDB.SaveChanges();
    }
    catch (Exception e)
    {
      throw e;
    }

  }

  public dynamic Getuser(string emailId)
  {
    try
    {

      return _insuranceDB.AuthDetails.FirstOrDefault(x => x.Email == emailId);

    }
    catch (Exception e)
    {

      throw e;

    }
  }
}