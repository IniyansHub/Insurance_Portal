﻿using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class ConfigureServices
{
  public static IServiceCollection AddApplication(this IServiceCollection services){
    services.AddScoped<IAuthenticationService,AuthenticationService>();
    return services;
  }
}