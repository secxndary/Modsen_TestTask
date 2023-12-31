using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Entities.Authentication;
using Entities.ConfigurationModels;
using Entities.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Handlers.Authentication;

public class BaseAuthenticationHandler(UserManager<User> userManager, IOptions<JwtConfiguration> configuration, IHttpContextAccessor httpContextAccessor)
{
    private protected readonly JwtConfiguration JwtConfiguration = configuration.Value;

    private protected SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(Constants.Secret)!);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private protected async Task<List<Claim>> GetClaims()
    {
        var user = httpContextAccessor.HttpContext!.Items[Constants.User] as User;
        if (user is null)
            throw new Exception($"{nameof(GetClaims)}: User object is null");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName!)
        };

        var roles = await userManager.GetRolesAsync(user!);
        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        return claims;
    }

    private protected JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken
        (
            issuer: JwtConfiguration.ValidIssuer,
            audience: JwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(JwtConfiguration.AccessExpiresMinutes)),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }

    private protected string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private protected ClaimsPrincipal GetPrincipalForExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = JwtConfiguration.ValidateLifetime,
            ValidateIssuerSigningKey = true,

            ValidIssuer = JwtConfiguration.ValidIssuer,
            ValidAudience = JwtConfiguration.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(Constants.Secret)!))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals
            (SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }
}