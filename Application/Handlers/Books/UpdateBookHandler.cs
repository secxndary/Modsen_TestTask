using Application.Commands.Books;
using AutoMapper;
using Contracts.Repositories;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers.Books;

public sealed class UpdateBookHandler(IRepositoryManager _repository, IMapper _mapper)
    : BookHandlerBase(_repository), IRequestHandler<UpdateBookCommand, BookDto>
{
    public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        await CheckIfAuthorExists(request.BookForUpdate.AuthorId);
        var bookEntity = await GetBookAndCheckIfItExists(request.Id, trackChanges: true);

        _mapper.Map(request.BookForUpdate, bookEntity);
        await _repository.SaveAsync();

        var bookToReturn = _mapper.Map<BookDto>(bookEntity);
        return bookToReturn;
    }
}