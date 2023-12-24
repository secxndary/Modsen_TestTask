using Entities.Models;

namespace Contracts.Repositories.UserRepositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
    Task<Author?> GetAuthorAsync(Guid id, bool trackChanges);
    void CreateAuthor(Author author);
    void DeleteAuthor(Author author);
}