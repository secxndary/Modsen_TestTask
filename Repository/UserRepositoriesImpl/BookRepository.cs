using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.UserRepositoriesImpl;

public class BookRepository(RepositoryContext repositoryContext) : RepositoryBase<Book>(repositoryContext), IBookRepository
{
    public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges)
    {
        var books = await FindAll(trackChanges)
            .ToListAsync();
        return books;
    }

    public async Task<Book?> GetBookAsync(Guid id, bool trackChanges)
    {
        var book = await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
        return book;
    }

    public void CreateBook(Book book) =>
        Create(book);

    public void DeleteBook(Book book) =>
        Delete(book);
}