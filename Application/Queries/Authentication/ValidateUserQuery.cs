using MediatR;
using Shared.DataTransferObjects.AuthenticationDtos;

namespace Application.Queries.Authentication;

public sealed record ValidateUserQuery(UserForAuthenticationDto UserForAuthentication) : IRequest<bool>;