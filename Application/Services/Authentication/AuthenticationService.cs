using System.Dynamic;
using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Application.Models;

namespace Insurance_Portal.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IAuthRepository _authRepo;
  public AuthenticationService(IAuthRepository authRepo)
  {
    _authRepo = authRepo;
  }

  public LoginResponse Login(string email, string password)
  {
    var userFound = _authRepo.Getuser(email);
    if (userFound != null)
    {
      string actualPassword = userFound.Password;

      if (actualPassword == password)
      {
        
        return new LoginResponse(userFound.Email, "sometoken");

      }
      else
      {

        throw new Exception("Incorrect password");

      }
    }
    else
    {
      throw new Exception("No user found with this email");
    }
  }

  public RegisterResponse Register(string email, string password)
  {
    var userFound = _authRepo.Getuser(email);
    if (userFound != null)
    {
      throw new Exception("User already exists");
    }
    else
    {
      var authObj = new {Email = email, Password = password};
      //Console.Write(authObj);
      try
      {
        _authRepo.AddUser(authObj);
        return new RegisterResponse(email);
      }
      catch (Exception e)
      {
        throw new Exception("Unable to register user in the database ", e);
      }

    }
  }
}