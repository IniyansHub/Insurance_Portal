using Insurance_Portal.Domain.Entities;

namespace Insurance_Portal.Application.Interfaces;
public interface IUserDetailRepository
{
  public Task<UserDetail> GetUserDetail(string email);
  public Task<UserDetail> CreateUserDetail(UserDetail userDetail);
  public Task<UserDetail> UpdateUserDetail(UserDetail userDetail);
}