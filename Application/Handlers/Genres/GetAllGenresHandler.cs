using Application.Queries.Genres;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Genres;

public sealed class GetAllGenresHandler(IRepositoryManager repository, IMapper mapper)
    : BaseGenreHandler(repository), IRequestHandler<GetAllGenresQuery, IEnumerable<GenreDto>>
{
    public async Task<IEnumerable<GenreDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await repository.Genre.GetAllGenresAsync(trackChanges: false);
        var genresDto = mapper.Map<IEnumerable<GenreDto>>(genres);
        return genresDto;
    }
}