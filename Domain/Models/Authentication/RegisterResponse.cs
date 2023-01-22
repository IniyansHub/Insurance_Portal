namespace Domain;

public record RegisterResponse(
  string email,
  bool isAdmin
);