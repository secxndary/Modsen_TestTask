using MediatR;

namespace Application.Commands.Authors;

public sealed record DeleteAuthorCommand(Guid Id) : IRequest;