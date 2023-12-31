using MediatR;
using Shared.DataTransferObjects.AuthenticationDtos;

namespace Application.Commands.Authentication;

public sealed record CreateTokenCommand(bool PopulateExpiration) : IRequest<TokenDto>;