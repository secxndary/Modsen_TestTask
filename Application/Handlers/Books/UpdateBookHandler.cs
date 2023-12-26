using Application.Commands.Books;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Books;

public sealed class UpdateBookHandler(IRepositoryManager repository, IMapper mapper)
    : BaseBookHandler(repository), IRequestHandler<UpdateBookCommand, BookDto>
{
    public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        await CheckIfAuthorExists(request.BookForUpdate.AuthorId);
        var bookEntity = await GetBookAndCheckIfItExists(request.Id, trackChanges: true);

        mapper.Map(request.BookForUpdate, bookEntity);
        await repository.SaveAsync();

        var bookToReturn = mapper.Map<BookDto>(bookEntity);
        return bookToReturn;
    }
}