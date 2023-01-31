using Insurance_Portal.Domain.DTO;
using Insurance_Portal.Domain.Entities;

public interface IUserDetailService
{
  public Task<UserDetailResponseDTO> GetUserDetail(string email);
  public Task<UserDetailResponseDTO> CreateUserDetail(UserDetail newUserDetail);
  public Task<UserDetailResponseDTO> UpdateUserDetail(UserDetail updatedDetail);
}