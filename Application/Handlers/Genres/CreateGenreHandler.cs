using Application.Commands.Genres;
using AutoMapper;
using Contracts.Repositories;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Genres;

public sealed class CreateGenreHandler(IRepositoryManager repository, IMapper mapper)
    : BaseGenreHandler(repository), IRequestHandler<CreateGenreCommand, GenreDto>
{
    public async Task<GenreDto> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genreEntity = mapper.Map<Genre>(request.Genre);

        repository.Genre.CreateGenre(genreEntity);
        await repository.SaveAsync();

        var genreToReturn = mapper.Map<GenreDto>(genreEntity);
        return genreToReturn;
    }
}