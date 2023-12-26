using AutoMapper;
using Contracts.Repositories;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Services.UserServicesImpl;

public sealed class BookService(IRepositoryManager repository, IMapper mapper) : IBookService
{
    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        var books = await repository.Book.GetAllBooksAsync(trackChanges: false);
        var booksDto = mapper.Map<IEnumerable<BookDto>>(books);
        return booksDto;
    }

    public async Task<BookDto> GetBookAsync(Guid id)
    {
        var book = await GetBookAndCheckIfItExists(id, trackChanges: false);
        var bookDto = mapper.Map<BookDto>(book);
        return bookDto;
    }

    public async Task<BookDto> CreateBookAsync(BookForCreationDto book)
    {
        var bookEntity = mapper.Map<Book>(book);

        repository.Book.CreateBook(bookEntity);
        await repository.SaveAsync();

        var bookToReturn = mapper.Map<BookDto>(bookEntity);
        return bookToReturn;
    }

    public async Task<BookDto> UpdateBookAsync(Guid id, BookForUpdateDto bookForUpdate)
    {
        var bookEntity = GetBookAndCheckIfItExists(id, trackChanges: true);

        await mapper.Map(bookForUpdate, bookEntity);
        await repository.SaveAsync();

        var bookToReturn = mapper.Map<BookDto>(bookEntity);
        return bookToReturn;
    }

    public async Task DeleteBookAsync(Guid id)
    {
        var book = await GetBookAndCheckIfItExists(id, trackChanges: false);
        repository.Book.DeleteBook(book);
        await repository.SaveAsync();
    }


    private async Task<Book> GetBookAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var book = await repository.Book.GetBookAsync(id, trackChanges);
        if (book is null)
            throw new BookNotFoundException(id);
        return book;
    }

    private async Task CheckIfAuthorExists(Guid authorId)
    {
        var author = await repository.Author.GetAuthorAsync(authorId, trackChanges: false);
        if (author is null)
            throw new AuthorNotFoundException(authorId);
    }

    private async Task CheckIfGenreExists(Guid genreId)
    {
        var genre = await repository.Genre.GetGenreAsync(genreId, trackChanges: false);
        if (genre is null)
            throw new AuthorNotFoundException(genreId);
    }
}