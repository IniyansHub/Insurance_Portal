using Insurance_Portal.Infrastructure.Persistance;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Insurance_Portal.Infrastructure.Repository;
using Insurance_Portal.Application.Interfaces;

namespace Infrastructure;
public static class ConfigureServices
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {

    var connectionString = configuration.GetConnectionString("DefaultConnection");

    services.AddDbContext<InsuranceDBContext>(options =>
    {
      options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });

    services.AddScoped<IAuthRepository, AuthRepository>();
    services.AddScoped<IPolicyRepository, PolicyRepository>();
    services.AddScoped<IUserDetailRepository, UserDetailRepository>();
    services.AddScoped<IUserPolicyRepository, UserPolicyRepository>();
    return services;

  }
}