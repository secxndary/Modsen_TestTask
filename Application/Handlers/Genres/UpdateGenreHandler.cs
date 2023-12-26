using Application.Commands.Genres;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Genres;

public sealed class UpdateGenreHandler(IRepositoryManager repository, IMapper mapper)
    : BaseGenreHandler(repository), IRequestHandler<UpdateGenreCommand, GenreDto>
{
    public async Task<GenreDto> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genreEntity = await GetGenreAndCheckIfItExists(request.Id, trackChanges: true);

        mapper.Map(request.GenreForUpdate, genreEntity);
        await repository.SaveAsync();

        var genreToReturn = mapper.Map<GenreDto>(genreEntity);
        return genreToReturn;
    }
}