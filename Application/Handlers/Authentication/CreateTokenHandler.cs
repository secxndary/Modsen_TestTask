using System.IdentityModel.Tokens.Jwt;
using Application.Commands.Authentication;
using Entities.Authentication;
using Entities.ConfigurationModels;
using Entities.Utilities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Shared.DataTransferObjects.AuthenticationDtos;

namespace Application.Handlers.Authentication;

public sealed class CreateTokenHandler(UserManager<User> userManager, IOptionsSnapshot<JwtConfiguration> configuration, IHttpContextAccessor httpContextAccessor)
    : BaseAuthenticationHandler(userManager, configuration, httpContextAccessor), IRequestHandler<CreateTokenCommand, TokenDto>
{
    public async Task<TokenDto> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var user = httpContextAccessor.HttpContext!.Items[Constants.User] as User;

        var refreshToken = GenerateRefreshToken();
        user!.RefreshToken = refreshToken;

        if (request.PopulateExpiration)
            user.RefreshTokenExpiryTime = DateTime.SpecifyKind(DateTime.Now.AddDays(Convert.ToDouble(JwtConfiguration.RefreshExpiresDays)), DateTimeKind.Utc);

        await userManager.UpdateAsync(user);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new TokenDto(accessToken, refreshToken);
    }
}