using Contracts.Repositories;
using Entities.Exceptions.NotFound;
using Entities.Models;

namespace Application.Handlers.Books;

public abstract class BaseBookHandler(IRepositoryManager repository)
{
    protected async Task<Book> GetBookAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var book = await repository.Book.GetBookAsync(id, trackChanges);
        if (book is null)
            throw new BookNotFoundException(id);
        return book;
    }

    protected async Task CheckIfAuthorExists(Guid authorId)
    {
        var author = await repository.Author.GetAuthorAsync(authorId, trackChanges: false);
        if (author is null)
            throw new AuthorNotFoundException(authorId);
    }

    protected async Task CheckIfGenreExists(Guid genreId)
    {
        var genre = await repository.Genre.GetGenreAsync(genreId, trackChanges: false);
        if (genre is null)
            throw new AuthorNotFoundException(genreId);
    }
}