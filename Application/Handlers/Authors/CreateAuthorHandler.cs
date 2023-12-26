using Application.Commands.Authors;
using AutoMapper;
using Contracts.Repositories;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Authors;

public sealed class CreateAuthorHandler(IRepositoryManager repository, IMapper mapper)
    : BaseAuthorHandler(repository), IRequestHandler<CreateAuthorCommand, AuthorDto>
{
    public async Task<AuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var authorEntity = mapper.Map<Author>(request.Author);

        repository.Author.CreateAuthor(authorEntity);
        await repository.SaveAsync();

        var authorToReturn = mapper.Map<AuthorDto>(authorEntity);
        return authorToReturn;
    }
}