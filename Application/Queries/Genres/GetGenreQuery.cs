using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Queries.Genres;

public sealed record GetGenreQuery(Guid Id) : IRequest<GenreDto>;