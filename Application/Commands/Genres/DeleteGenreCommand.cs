using MediatR;

namespace Application.Commands.Genres;

public sealed record DeleteGenreCommand(Guid Id) : IRequest;