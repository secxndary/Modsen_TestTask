using Contracts.Repositories;
using Service.Contracts;
using Service.Contracts.UserServices;
using Services.UserServicesImpl;

namespace Services;

public class ServiceManager(IRepositoryManager repository) : IServiceManager
{
    private readonly Lazy<IBookService> _bookService = new(() => new BookService(repository));
    private readonly Lazy<IAuthorService> _authorService = new (() => new AuthorService(repository));
    private readonly Lazy<IGenreService> _genreService = new(() => new GenreService(repository));

    public IBookService BookService => _bookService.Value;
    public IAuthorService AuthorService => _authorService.Value;
    public IGenreService GenreService => _genreService.Value;
}