using Contracts.Repositories.UserRepositories;

namespace Contracts.Repositories;

public interface IRepositoryManager
{
    IBookRepository Book { get; }
    IAuthorRepository Author { get; }
    IGenreRepository Genre { get; }
    Task SaveAsync();
}