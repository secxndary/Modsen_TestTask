using Application.Commands.Genres;
using Contracts.Repositories;
using MediatR;

namespace Application.Handlers.Genres;

public sealed class DeleteGenreHandler(IRepositoryManager repository)
    : BaseGenreHandler(repository), IRequestHandler<DeleteGenreCommand, Unit>
{
    public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await GetGenreAndCheckIfItExists(request.Id, trackChanges: false);

        repository.Genre.DeleteGenre(genre);
        await repository.SaveAsync();

        return Unit.Value;
    }
}