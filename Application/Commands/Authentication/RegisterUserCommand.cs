using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects.AuthenticationDtos;

namespace Application.Commands.Authentication;

public sealed record RegisterUserCommand(UserForRegistrationDto UserForRegistration) : IRequest<IdentityResult>;