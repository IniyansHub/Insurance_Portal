using Insurance_Portal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class UserPolicyController : Controller
{

  private readonly IUserPolicyService _userPolicyService;

  public UserPolicyController(IUserPolicyService userPolicyService)
  {
    _userPolicyService = userPolicyService;
  }

  [HttpGet]
  [Route("{email}")]
  public ActionResult Get(string email)
  {
    var response = _userPolicyService.GetUserPolicies(email);
    return Ok(response);
  }


}