using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.UserRepositoriesImpl;

public class GenreRepository(RepositoryContext repositoryContext) : RepositoryBase<Genre>(repositoryContext), IGenreRepository
{
    public async Task<IEnumerable<Genre>> GetAllGenresAsync(bool trackChanges)
    {
        var genres = await FindAll(trackChanges)
            .ToListAsync();
        return genres;
    }

    public async Task<Genre?> GetGenreAsync(Guid id, bool trackChanges)
    {
        var genre = await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
        return genre;
    }

    public void CreateGenre(Genre genre) =>
        Create(genre);

    public void DeleteGenre(Genre genre) =>
        Delete(genre);
}