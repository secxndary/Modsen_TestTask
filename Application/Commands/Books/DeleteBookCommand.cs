using MediatR;

namespace Application.Commands.Books;

public sealed record DeleteBookCommand(Guid Id) : IRequest;