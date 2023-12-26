using MediatR;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Application.Commands.Genres;

public sealed record UpdateGenreCommand(Guid Id, GenreForUpdateDto GenreForUpdate) : IRequest<GenreDto>;