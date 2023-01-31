using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Application.Services;
using Insurance_Portal.Domain.DTO;
using Microsoft.Extensions.Configuration;

namespace Insurance_portal.Application.Services;
public class AuthService : IAuthService
{

  private readonly IAuthRepository _authRepo;
  private readonly IConfiguration _config;

  private readonly RegionEndpoint _region = RegionEndpoint.USEast1;

  public AuthService(IAuthRepository authRepo, IConfiguration config)
  {
    _authRepo = authRepo;
    _config = config;
  }

  public async Task<AuthResponseDTO> Login(string email, string password)
  {
    var congnitoDetails = HelperService.getCognitoDetails(_config);
    var response = new AuthResponseDTO();
    var cognito = new AmazonCognitoIdentityProviderClient(_region);
    var request = new AdminInitiateAuthRequest
    {
      UserPoolId = congnitoDetails["UserPoolId"],
      ClientId = congnitoDetails["ClientId"],
      AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH
    };
    request.AuthParameters.Add("USERNAME", email);
    request.AuthParameters.Add("PASSWORD", password);
    try
    {
      var cognitoResponse = await cognito.AdminInitiateAuthAsync(request);
      response.statusCode = (int)cognitoResponse.HttpStatusCode;
      response.message = "Logged in successfully";
      response.token = cognitoResponse.AuthenticationResult.IdToken;
    }
    catch (Exception e)
    {
      response.statusCode = 400;
      response.message = e.Message;
      response.token = null;
    }
    return response;
  }

  public async Task<AuthResponseDTO> Register(string email, string password)
  {
    var cognito = new AmazonCognitoIdentityProviderClient(_region);

    var cognitoDetails = HelperService.getCognitoDetails(_config);

    AuthResponseDTO response = new AuthResponseDTO();

    var request = new SignUpRequest
    {
      ClientId = cognitoDetails["ClientId"],
      Password = password,
      Username = email
    };

    var emailAttribute = new AttributeType
    {
      Name = "email",
      Value = email
    };

    request.UserAttributes.Add(emailAttribute);

    try
    {
      var signupResponse = await cognito.SignUpAsync(request);
      var groupRequest = new AdminAddUserToGroupRequest
      {
        GroupName = "Consumer",
        UserPoolId = cognitoDetails["UserPoolId"],
        Username = email
      };

      var AdminConfirmSignup = new AdminConfirmSignUpRequest
      {
        UserPoolId = cognitoDetails["UserPoolId"],
        Username = email
      };

      await cognito.AdminConfirmSignUpAsync(AdminConfirmSignup);

      var groupAddedResponse = await cognito.AdminAddUserToGroupAsync(groupRequest);

      response.statusCode = 200;
      response.message = "User registered successfully!";
      response.token = null;

    }
    catch (Exception e)
    {
      response.statusCode = 400;
      response.message = e.Message;
      response.token = null;
    }
    return response;
  }
}