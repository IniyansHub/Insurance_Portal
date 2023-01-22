namespace Insurance_Portal.Application.Models;

public record LoginResponse(
  string email,
  string token
);