using Insurance_Portal.Application.Models;

namespace Insurance_Portal.Application.Interfaces;

public interface IAuthenticationService{
  LoginResponse Login(string email, string password);
  RegisterResponse Register(string email, string password);
}