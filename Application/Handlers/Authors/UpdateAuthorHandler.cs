using Application.Commands.Authors;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Authors;

public sealed class UpdateAuthorHandler(IRepositoryManager repository, IMapper mapper)
    : BaseAuthorHandler(repository), IRequestHandler<UpdateAuthorCommand, AuthorDto>
{
    public async Task<AuthorDto> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var authorEntity = await GetAuthorAndCheckIfItExists(request.Id, trackChanges: true);

        mapper.Map(request.AuthorForUpdate, authorEntity);
        await repository.SaveAsync();

        var authorToReturn = mapper.Map<AuthorDto>(authorEntity);
        return authorToReturn;
    }
}