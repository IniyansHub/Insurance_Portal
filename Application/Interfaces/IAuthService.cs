using Insurance_Portal.Domain.DTO;
namespace Insurance_Portal.Application.Interfaces;
public interface IAuthService
{
  public Task<AuthResponseDTO> Login(string email,string password);
  public Task<AuthResponseDTO> Register(string email,string password);
  
}