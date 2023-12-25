using AutoMapper;
using Contracts.Repositories;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Services.UserServicesImpl;

public class AuthorService(IRepositoryManager _repository, IMapper _mapper) : IAuthorService
{
    public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<AuthorDto> GetAuthorAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthorDto> CreateAuthorAsync(AuthorForCreationDto author)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthorDto> UpdateAuthorAsync(AuthorForUpdateDto author)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAuthorAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}