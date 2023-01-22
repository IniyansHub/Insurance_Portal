namespace Domain;

public record AuthRequest(
  string email,
  string password
);