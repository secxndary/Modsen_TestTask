using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.UserRepositoriesImpl;

public class AuthorRepository(RepositoryContext repositoryContext) : RepositoryBase<Author>(repositoryContext), IAuthorRepository
{
    public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges)
    {
        var authors = await FindAll(trackChanges)
            .ToListAsync();
        return authors;
    }

    public async Task<Author?> GetAuthorAsync(Guid id, bool trackChanges)
    {
        var author = await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
        return author;
    }

    public void CreateAuthor(Author author) =>
        Create(author);

    public void DeleteAuthor(Author author) =>
        Delete(author);
}