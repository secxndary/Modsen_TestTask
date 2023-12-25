using AutoMapper;
using Contracts.Repositories;
using Service.Contracts;
using Service.Contracts.UserServices;
using Services.UserServicesImpl;

namespace Services;

public class ServiceManager(IRepositoryManager repository, IMapper mapper) : IServiceManager
{
    private readonly Lazy<IBookService> _bookService = new(() => new BookService(repository, mapper));
    private readonly Lazy<IAuthorService> _authorService = new (() => new AuthorService(repository, mapper));
    private readonly Lazy<IGenreService> _genreService = new(() => new GenreService(repository, mapper));

    public IBookService BookService => _bookService.Value;
    public IAuthorService AuthorService => _authorService.Value;
    public IGenreService GenreService => _genreService.Value;
}