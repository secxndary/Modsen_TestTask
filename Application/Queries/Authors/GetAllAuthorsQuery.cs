using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Queries.Authors;

public sealed record GetAllAuthorsQuery : IRequest<IEnumerable<AuthorDto>>;