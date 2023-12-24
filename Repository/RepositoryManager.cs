using Contracts.Repositories;
using Contracts.Repositories.UserRepositories;
using Repository.UserRepositoriesImpl;

namespace Repository;

public sealed class RepositoryManager(RepositoryContext repositoryContext) : IRepositoryManager
{
    private readonly Lazy<IBookRepository> _bookRepository = new(() => new BookRepository(repositoryContext));

    public IBookRepository Book => _bookRepository.Value;
    
    public async Task SaveAsync() => await repositoryContext.SaveChangesAsync();
}