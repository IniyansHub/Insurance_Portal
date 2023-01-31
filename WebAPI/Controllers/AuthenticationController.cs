using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
  private readonly IAuthService _authService;

  public AuthenticationController(IAuthService authService)
  {
    _authService = authService;
  }

  [HttpPost("login")]
  public async Task<ActionResult> Login(AuthRequestDTO loginBody)
  {
    var response = await _authService.Login(loginBody.email, loginBody.password);
    return Ok(response);
  }

  [HttpPost("register")]
  public async Task<ActionResult> Register(AuthRequestDTO registerBody)
  {

    var response = await _authService.Register(registerBody.email, registerBody.password);

    return Ok(response);

  }

}