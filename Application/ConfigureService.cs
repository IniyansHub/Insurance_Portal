using Microsoft.Extensions.DependencyInjection;
using Insurance_portal.Application.Services;
using Insurance_Portal.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Insurance_portal.Application;
public static class ConfigureServices
{
  public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
  {
    var CognitoDetails  = config.GetSection("CognitoDetails").GetChildren().ToDictionary(x => x.Key, x => x.Value);
    services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
      options.Audience = CognitoDetails["ClientId"];
      options.Authority = CognitoDetails["Authority"];
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            RoleClaimType = "cognito:group"
        };
    });

    services.AddAuthorization(options =>
    {
        options.AddPolicy("Admin", policy =>
    policy.RequireAssertion(context =>
    context.User.HasClaim(c => c.Type == "cognito:groups" && c.Value.Contains("Admin"))));
    });

    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IPolicyService, PolicyService>();
    services.AddScoped<IUserDetailService, UserDetailService>();
    services.AddScoped<IUserPolicyService, UserPolicyService>();
    return services;
  }
}