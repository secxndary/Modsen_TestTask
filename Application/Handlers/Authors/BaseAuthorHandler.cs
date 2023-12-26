using Contracts.Repositories;
using Entities.Exceptions.NotFound;
using Entities.Models;

namespace Application.Handlers.Authors;

public abstract class BaseAuthorHandler(IRepositoryManager repository)
{
    protected async Task<Author> GetAuthorAndCheckIfItExists(Guid authorId, bool trackChanges)
    {
        var author = await repository.Author.GetAuthorAsync(authorId, trackChanges);
        if (author is null)
            throw new AuthorNotFoundException(authorId);
        return author;
    }
}