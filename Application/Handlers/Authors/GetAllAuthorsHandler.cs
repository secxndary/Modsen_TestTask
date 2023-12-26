using Application.Queries.Authors;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Authors;

public sealed class GetAllAuthorsHandler(IRepositoryManager repository, IMapper mapper)
    : BaseAuthorHandler(repository), IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorDto>>
{
    public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await repository.Author.GetAllAuthorsAsync(trackChanges: false);
        var authorsDto = mapper.Map<IEnumerable<AuthorDto>>(authors);
        return authorsDto;
    }
}