using Application.Queries.Authors;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Authors;

public sealed class GetAuthorHandler(IRepositoryManager repository, IMapper mapper)
    : BaseAuthorHandler(repository), IRequestHandler<GetAuthorQuery, AuthorDto>
{
    public async Task<AuthorDto> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await GetAuthorAndCheckIfItExists(request.Id, trackChanges: false);
        var authorDto = mapper.Map<AuthorDto>(author);
        return authorDto;
    }
}