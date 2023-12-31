using Application.Commands.Authentication;
using AutoMapper;
using Entities.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Handlers.Authentication;

public sealed class RegisterUserHandler(IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    : IRequestHandler<RegisterUserCommand, IdentityResult>
{
    public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.UserForRegistration);
        var result = await userManager.CreateAsync(user, request.UserForRegistration.Password!);

        foreach (var role in request.UserForRegistration.Roles!)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "RoleNotExist",
                    Description = $"Role {role} does not exist."
                });
            }
        }

        if (result.Succeeded)
            await userManager.AddToRolesAsync(user, request.UserForRegistration.Roles!);

        return result;
    }
}