using Amazon;
using Microsoft.Extensions.Configuration;

namespace Insurance_Portal.Application.Services;

public static class HelperService
{

  public static dynamic getCognitoDetails(IConfiguration config)
  {
    return config.GetSection("CognitoDetails").GetChildren().ToDictionary(x => x.Key, x => x.Value);
  }

}