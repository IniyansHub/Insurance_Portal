using Insurance_Portal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Portal.Controllers;

[ApiController]
[Route("userdetail")]
public class UserDetailController : Controller
{
  private readonly IUserDetailService _userDetailService;
  public UserDetailController(IUserDetailService userDetailService)
  {
    _userDetailService = userDetailService;
  }

  [HttpGet]
  [Route("{email}")]
  public async Task<ActionResult> Get(string email)
  {
    var response = await _userDetailService.GetUserDetail(email);
    return Ok(response);
  }

  [HttpPost]
  [Route("add")]
  public async Task<ActionResult> Create(UserDetail newUserDetail)
  {
    var response = await _userDetailService.CreateUserDetail(newUserDetail);
    return Ok(response);
  }

  [HttpPut]
  [Route("update")]
  public async Task<ActionResult> Update(UserDetail updatedDetail)
  {
    var response = await _userDetailService.UpdateUserDetail(updatedDetail);
    return Ok(response);
  }

}