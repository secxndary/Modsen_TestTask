using Application.Commands.Books;
using Contracts.Repositories;
using MediatR;

namespace Application.Handlers.Books;

public sealed class DeleteBookHandler(IRepositoryManager _repository)
    : BookHandlerBase(_repository), IRequestHandler<DeleteBookCommand, Unit>
{
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await GetBookAndCheckIfItExists(request.Id, trackChanges: false);

        _repository.Book.DeleteBook(book);
        await _repository.SaveAsync();

        return Unit.Value;
    }
}