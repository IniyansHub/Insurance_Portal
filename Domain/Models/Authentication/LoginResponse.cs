namespace Domain;

public record LoginResponse(
  string email,
  string token
);