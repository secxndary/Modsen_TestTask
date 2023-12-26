using Application.Queries.Books;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Books;

public sealed class GetAllBooksHandler(IRepositoryManager repository, IMapper mapper)
    : BaseBookHandler(repository), IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await repository.Book.GetAllBooksAsync(trackChanges: false);
        var booksDto = mapper.Map<IEnumerable<BookDto>>(books);
        return booksDto;
    }
}