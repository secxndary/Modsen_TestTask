using Application.Queries.Genres;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Genres;

public sealed class GetGenreHandler(IRepositoryManager repository, IMapper mapper)
    : BaseGenreHandler(repository), IRequestHandler<GetGenreQuery, GenreDto>
{
    public async Task<GenreDto> Handle(GetGenreQuery request, CancellationToken cancellationToken)
    {
        var genre = await GetGenreAndCheckIfItExists(request.Id, trackChanges: false);
        var genreDto = mapper.Map<GenreDto>(genre);
        return genreDto;
    }
}