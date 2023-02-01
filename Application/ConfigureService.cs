using Microsoft.Extensions.DependencyInjection;
using Insurance_portal.Application.Services;
using Insurance_Portal.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Insurance_Portal.Application.Services;

namespace Insurance_portal.Application;
public static class ConfigureServices
{
  public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
  {
    var CognitoDetails = HelperService.getCognitoDetails(config);
    services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
      options.Audience = CognitoDetails["ClientId"];
      options.Authority = CognitoDetails["Authority"];
      options.TokenValidationParameters = new TokenValidationParameters()
      {
        RoleClaimType = "cognito:groups"
      };
    });

    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IPolicyService, PolicyService>();
    services.AddScoped<IUserDetailService, UserDetailService>();
    services.AddScoped<IUserPolicyService, UserPolicyService>();
    return services;
  }
}