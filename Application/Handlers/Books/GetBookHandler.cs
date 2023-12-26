using Application.Queries.Books;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Books;

public sealed class GetBookHandler(IRepositoryManager repository, IMapper mapper)
    : BaseBookHandler(repository), IRequestHandler<GetBookQuery, BookDto>
{
    public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await GetBookAndCheckIfItExists(request.Id, trackChanges: false);
        var bookDto = mapper.Map<BookDto>(book);
        return bookDto;
    }
}