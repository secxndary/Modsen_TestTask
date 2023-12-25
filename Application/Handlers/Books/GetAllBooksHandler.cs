using Application.Queries.Books;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Books;

public sealed class GetAllBooksHandler(IRepositoryManager _repository, IMapper _mapper) : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _repository.Book.GetAllBooksAsync(trackChanges: false);
        var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
        return booksDto;
    }
}