using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Service.Contracts.UserServices;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();   // TODO add AuthorParameters
    Task<AuthorDto> GetAuthorAsync(Guid id);
    Task<AuthorDto> CreateAuthorAsync(AuthorForCreationDto author);
    Task<AuthorDto> UpdateAuthorAsync(Guid id, AuthorForUpdateDto authorForUpdate);
    Task DeleteAuthorAsync(Guid id);
}