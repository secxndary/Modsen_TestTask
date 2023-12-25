using Application.Commands.Books;
using AutoMapper;
using Contracts.Repositories;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Books;

public sealed class CreateBookHandler(IRepositoryManager _repository, IMapper _mapper)
    : BookHandlerBase(_repository), IRequestHandler<CreateBookCommand, BookDto>
{
    public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        await CheckIfAuthorExists(request.Book.AuthorId);   // TODO CheckIfGenreExists

        var bookEntity = _mapper.Map<Book>(request.Book);

        _repository.Book.CreateBook(bookEntity);
        await _repository.SaveAsync();

        var bookToReturn = _mapper.Map<BookDto>(bookEntity);
        return bookToReturn;
    }
}