using Application.Commands.Authors;
using Contracts.Repositories;
using MediatR;

namespace Application.Handlers.Authors;

public sealed class DeleteAuthorHandler(IRepositoryManager repository)
    : BaseAuthorHandler(repository), IRequestHandler<DeleteAuthorCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await GetAuthorAndCheckIfItExists(request.Id, trackChanges: false);

        repository.Author.DeleteAuthor(author);
        await repository.SaveAsync();

        return Unit.Value;
    }
}