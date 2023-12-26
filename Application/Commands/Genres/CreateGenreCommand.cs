using MediatR;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Commands.Genres;

public sealed record CreateGenreCommand(GenreForCreationDto Genre) : IRequest<GenreDto>;