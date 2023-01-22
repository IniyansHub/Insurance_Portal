namespace Insurance_Portal.Application.Interfaces;

public interface IAuthRepository
{
  dynamic Getuser(string emailId);
  void AddUser(dynamic entity);
}