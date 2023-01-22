using Domain;
using Insurance_Portal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Portal.WebAPI.Controllers.Authencation;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{

  private readonly IAuthenticationService _authenticationService;

  public AuthenticationController(IAuthenticationService authenticationService)
  {
    _authenticationService = authenticationService;
  }

  [HttpPost("register")]
  public ActionResult Register(AuthRequest request)
  {
    try
    {

      var authResult = _authenticationService.Register(request.email, request.password);
      return Ok(authResult);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message); 
    }
  }

  [HttpPost("login")]
  public ActionResult Login(AuthRequest request)
  {
    try
    {
      var authResult = _authenticationService.Login(request.email, request.password);
      return Ok(authResult);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}