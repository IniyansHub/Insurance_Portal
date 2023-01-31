using Insurance_Portal.Domain.Entities;
namespace Insurance_Portal.Application.Interfaces;
public interface IAuthRepository
{
  public Task<AuthDetail> FindUser(string email);
  public void AddUser(AuthDetail authDetail);

}