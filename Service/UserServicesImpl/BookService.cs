using AutoMapper;
using Contracts.Repositories;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Services.UserServicesImpl;

public sealed class BookService(IRepositoryManager _repository, IMapper _mapper) : IBookService
{
    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        var books = await _repository.Book.GetAllBooksAsync(trackChanges: false);
        var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
        return booksDto;
    }

    public async Task<BookDto> GetBookAsync(Guid id)
    {
        var book = await GetBookAndCheckIfItExists(id, trackChanges: false);
        var bookDto = _mapper.Map<BookDto>(book);
        return bookDto;
    }

    public async Task<BookDto> CreateBookAsync(BookForCreationDto book)
    {
        var bookEntity = _mapper.Map<Book>(book);

        _repository.Book.CreateBook(bookEntity);
        await _repository.SaveAsync();

        var bookToReturn = _mapper.Map<BookDto>(bookEntity);
        return bookToReturn;
    }

    public async Task<BookDto> UpdateBookAsync(Guid id, BookForUpdateDto bookForUpdate)
    {
        var bookEntity = GetBookAndCheckIfItExists(id, trackChanges: true);

        await _mapper.Map(bookForUpdate, bookEntity);
        await _repository.SaveAsync();

        var bookToReturn = _mapper.Map<BookDto>(bookEntity);
        return bookToReturn;
    }

    public async Task DeleteBookAsync(Guid id)
    {
        var book = await GetBookAndCheckIfItExists(id, trackChanges: false);
        _repository.Book.DeleteBook(book);
        await _repository.SaveAsync();
    }


    private async Task<Book> GetBookAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var book = await _repository.Book.GetBookAsync(id, trackChanges);
        if (book is null)
            throw new BookNotFoundException(id);
        return book;
    }

    private async Task CheckIfAuthorExists(Guid authorId)
    {
        var author = await _repository.Author.GetAuthorAsync(authorId, trackChanges: false);
        if (author is null)
            throw new AuthorNotFoundException(authorId);
    }

    private async Task CheckIfGenreExists(Guid genreId)
    {
        var genre = await _repository.Genre.GetGenreAsync(genreId, trackChanges: false);
        if (genre is null)
            throw new AuthorNotFoundException(genreId);
    }
}