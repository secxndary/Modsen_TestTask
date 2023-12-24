using Service.Contracts.UserServices;

namespace Service.Contracts;

public interface IServiceManager
{
    public IBookService BookService { get; }
    public IAuthorService AuthorService { get; }
    public IGenreService GenreService { get; }
}