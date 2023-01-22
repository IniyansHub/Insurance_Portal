using Infrastructure.Persistance;
using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Infrastructure.Persistance.Respository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class ConfigureServices
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
    
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    
    services.AddDbContext<InsuranceDbContext>(options=>{
      options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
    });

    services.AddScoped<IAuthRepository,AuthRepo>();
    
    return services;
  
  }
}