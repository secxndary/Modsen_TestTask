using Application.Commands.Authentication;
using Entities.Authentication;
using Entities.ConfigurationModels;
using Entities.Exceptions.BadRequest;
using Entities.Utilities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Shared.DataTransferObjects.AuthenticationDtos;

namespace Application.Handlers.Authentication;

public sealed class RefreshTokenHandler(UserManager<User> userManager, IOptions<JwtConfiguration> configuration, ISender sender, IHttpContextAccessor httpContextAccessor)
    : BaseAuthenticationHandler(userManager, configuration, httpContextAccessor), IRequestHandler<RefreshTokenCommand, TokenDto>
{
    public async Task<TokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var principal = GetPrincipalForExpiredToken(request.TokenDto.AccessToken);

        var userByManager = await userManager.FindByNameAsync(principal.Identity!.Name!);
        if (userByManager == null || userByManager.RefreshToken != request.TokenDto.RefreshToken || userByManager.RefreshTokenExpiryTime <= DateTime.Now)
            throw new RefreshTokenBadRequest();

        httpContextAccessor.HttpContext!.Items[Constants.User] = userByManager;
        return await sender.Send(new CreateTokenCommand(PopulateExpiration: false), cancellationToken);
    }
}