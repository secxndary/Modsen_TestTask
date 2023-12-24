using Contracts.Repositories.UserRepositories;

namespace Contracts.Repositories;

public interface IRepositoryManager
{
    IBookRepository Book { get; }
    Task SaveAsync();
}