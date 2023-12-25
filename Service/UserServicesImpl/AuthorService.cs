using AutoMapper;
using Contracts.Repositories;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Services.UserServicesImpl;

public class AuthorService(IRepositoryManager _repository, IMapper _mapper) : IAuthorService
{
    public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
    {
        var authors = await _repository.Author.GetAllAuthorsAsync(trackChanges: false);
        var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);
        return authorsDto;
    }

    public async Task<AuthorDto> GetAuthorAsync(Guid id)
    {
        var author = await GetAuthorAndCheckIfItExists(id, trackChanges: false);
        var authorDto = _mapper.Map<AuthorDto>(author);
        return authorDto;
    }

    public async Task<AuthorDto> CreateAuthorAsync(AuthorForCreationDto author)
    {
        var authorEntity = _mapper.Map<Author>(author);

        _repository.Author.CreateAuthor(authorEntity);
        await _repository.SaveAsync();

        var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
        return authorToReturn;
    }

    public async Task<AuthorDto> UpdateAuthorAsync(Guid id, AuthorForUpdateDto authorForUpdate)
    {
        var authorEntity = GetAuthorAndCheckIfItExists(id, trackChanges: true);

        await _mapper.Map(authorForUpdate, authorEntity);
        await _repository.SaveAsync();

        var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
        return authorToReturn;
    }

    public async Task DeleteAuthorAsync(Guid id)
    {
        var author = await GetAuthorAndCheckIfItExists(id, trackChanges: false);
        _repository.Author.DeleteAuthor(author);
        await _repository.SaveAsync();
    }
    
    
    private async Task<Author> GetAuthorAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var author = await _repository.Author.GetAuthorAsync(id, trackChanges);
        if (author is null)
            throw new AuthorNotFoundException(id);
        return author;
    }
}