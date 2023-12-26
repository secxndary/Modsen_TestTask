using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Queries.Genres;

public sealed record GetAllGenresQuery : IRequest<IEnumerable<GenreDto>>;