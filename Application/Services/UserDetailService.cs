using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Domain.DTO;
using Insurance_Portal.Domain.Entities;

namespace Insurance_portal.Application.Services;
public class UserDetailService : IUserDetailService
{
  private readonly IUserDetailRepository _userDetailRepo;

  public UserDetailService(IUserDetailRepository userDetailRepo)
  {
    _userDetailRepo = userDetailRepo;
  }

  public async Task<UserDetailResponseDTO> CreateUserDetail(UserDetail newUserDetail)
  {
    var response = new UserDetailResponseDTO();
    var userDetail = await _userDetailRepo.CreateUserDetail(newUserDetail);
    if (userDetail != null)
    {
      response.statusCode = 200;
      response.message = "Created a new user detail";
      response.userDetail = userDetail;
      return response;
    }
    else
    {
      response.statusCode = 400;
      response.message = "Unable to add user detail";
      response.userDetail = null;
      return response;
    }
  }

  public async Task<UserDetailResponseDTO> GetUserDetail(string email)
  {
    var response = new UserDetailResponseDTO();
    UserDetail userDetail = await _userDetailRepo.GetUserDetail(email);
    if (userDetail != null)
    {
      response.statusCode = 200;
      response.message = "User detail fetched successfully";
      response.userDetail = userDetail;
      return response;
    }
    else
    {
      response.statusCode = 404;
      response.message = "User detail not found with this email";
      response.userDetail = null;
      return response;
    }
  }

  public async Task<UserDetailResponseDTO> UpdateUserDetail(UserDetail updatedDetail)
  {
    var response = new UserDetailResponseDTO();
    var userDetail = await _userDetailRepo.UpdateUserDetail(updatedDetail);
    if (userDetail != null)
    {
      response.statusCode = 200;
      response.message = "user detail updated successfully!";
      response.userDetail = userDetail;
      return response;
    }
    else
    {
      response.statusCode = 400;
      response.message = "Unable to update user detail";
      response.userDetail = null;
      return response;
    }
  }
}