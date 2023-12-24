using Microsoft.AspNetCore.Identity;

namespace Entities.Authentication;

public class User : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}