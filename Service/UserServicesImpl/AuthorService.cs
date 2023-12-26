using AutoMapper;
using Contracts.Repositories;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Services.UserServicesImpl;

public class AuthorService(IRepositoryManager repository, IMapper mapper) : IAuthorService
{
    public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
    {
        var authors = await repository.Author.GetAllAuthorsAsync(trackChanges: false);
        var authorsDto = mapper.Map<IEnumerable<AuthorDto>>(authors);
        return authorsDto;
    }

    public async Task<AuthorDto> GetAuthorAsync(Guid id)
    {
        var author = await GetAuthorAndCheckIfItExists(id, trackChanges: false);
        var authorDto = mapper.Map<AuthorDto>(author);
        return authorDto;
    }

    public async Task<AuthorDto> CreateAuthorAsync(AuthorForCreationDto author)
    {
        var authorEntity = mapper.Map<Author>(author);

        repository.Author.CreateAuthor(authorEntity);
        await repository.SaveAsync();

        var authorToReturn = mapper.Map<AuthorDto>(authorEntity);
        return authorToReturn;
    }

    public async Task<AuthorDto> UpdateAuthorAsync(Guid id, AuthorForUpdateDto authorForUpdate)
    {
        var authorEntity = GetAuthorAndCheckIfItExists(id, trackChanges: true);

        await mapper.Map(authorForUpdate, authorEntity);
        await repository.SaveAsync();

        var authorToReturn = mapper.Map<AuthorDto>(authorEntity);
        return authorToReturn;
    }

    public async Task DeleteAuthorAsync(Guid id)
    {
        var author = await GetAuthorAndCheckIfItExists(id, trackChanges: false);
        repository.Author.DeleteAuthor(author);
        await repository.SaveAsync();
    }
    
    
    private async Task<Author> GetAuthorAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var author = await repository.Author.GetAuthorAsync(id, trackChanges);
        if (author is null)
            throw new AuthorNotFoundException(id);
        return author;
    }
}