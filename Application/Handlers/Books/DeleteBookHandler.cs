using Application.Commands.Books;
using Contracts.Repositories;
using MediatR;

namespace Application.Handlers.Books;

public sealed class DeleteBookHandler(IRepositoryManager repository)
    : BaseBookHandler(repository), IRequestHandler<DeleteBookCommand, Unit>
{
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await GetBookAndCheckIfItExists(request.Id, trackChanges: false);

        repository.Book.DeleteBook(book);
        await repository.SaveAsync();

        return Unit.Value;
    }
}