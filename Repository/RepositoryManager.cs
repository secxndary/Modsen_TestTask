using Contracts.Repositories;
using Contracts.Repositories.UserRepositories;
using Repository.UserRepositoriesImpl;

namespace Repository;

public sealed class RepositoryManager(RepositoryContext repositoryContext) : IRepositoryManager
{
    private readonly Lazy<IBookRepository> _bookRepository = new(() => new BookRepository(repositoryContext));
    private readonly Lazy<IAuthorRepository> _authorRepository = new(() => new AuthorRepository(repositoryContext));
    private readonly Lazy<IGenreRepository> _genreRepository = new(() => new GenreRepository(repositoryContext));
    
    public IBookRepository Book => _bookRepository.Value;
    public IAuthorRepository Author => _authorRepository.Value;
    public IGenreRepository Genre => _genreRepository.Value;
    
    public async Task SaveAsync() => await repositoryContext.SaveChangesAsync();
}