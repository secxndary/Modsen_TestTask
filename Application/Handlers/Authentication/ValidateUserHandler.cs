using Application.Queries.Authentication;
using Contracts;
using Entities.Authentication;
using Entities.ConfigurationModels;
using Entities.Utilities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Application.Handlers.Authentication;

public sealed class ValidateUserHandler(UserManager<User> userManager, IOptionsSnapshot<JwtConfiguration> configuration, ILoggerManager logger, IHttpContextAccessor httpContextAccessor)
    : BaseAuthenticationHandler(userManager, configuration, httpContextAccessor), IRequestHandler<ValidateUserQuery, bool>
{
    public async Task<bool> Handle(ValidateUserQuery request, CancellationToken cancellationToken)
    {
        httpContextAccessor.HttpContext!.Items[Constants.User] = await userManager.FindByNameAsync(request.UserForAuthentication.UserName!);
        var user = httpContextAccessor.HttpContext!.Items[Constants.User] as User;

        var result = user != null &&
                     await userManager.CheckPasswordAsync(user, request.UserForAuthentication.Password!);

        if (!result)
            logger.LogWarn($"{nameof(ValidateUserHandler)}: Authentication failed. Incorrect username or password.");

        return result;
    }
}