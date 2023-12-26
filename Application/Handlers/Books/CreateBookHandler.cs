using Application.Commands.Books;
using AutoMapper;
using Contracts.Repositories;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Books;

public sealed class CreateBookHandler(IRepositoryManager repository, IMapper mapper)
    : BaseBookHandler(repository), IRequestHandler<CreateBookCommand, BookDto>
{
    public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        await CheckIfAuthorExists(request.Book.AuthorId);   // TODO CheckIfGenreExists

        var bookEntity = mapper.Map<Book>(request.Book);

        repository.Book.CreateBook(bookEntity);
        await repository.SaveAsync();

        var bookToReturn = mapper.Map<BookDto>(bookEntity);
        return bookToReturn;
    }
}