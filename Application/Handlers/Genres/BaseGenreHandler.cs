using Contracts.Repositories;
using Entities.Exceptions.NotFound;
using Entities.Models;

namespace Application.Handlers.Genres;

public abstract class BaseGenreHandler(IRepositoryManager repository)
{
    protected async Task<Genre> GetGenreAndCheckIfItExists(Guid genreId, bool trackChanges)
    {
        var genre = await repository.Genre.GetGenreAsync(genreId, trackChanges);
        if (genre is null)
            throw new GenreNotFoundException(genreId);
        return genre;
    }
}