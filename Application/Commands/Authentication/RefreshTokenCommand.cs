using MediatR;
using Shared.DataTransferObjects.AuthenticationDtos;

namespace Application.Commands.Authentication;

public sealed record RefreshTokenCommand(TokenDto TokenDto) : IRequest<TokenDto>;