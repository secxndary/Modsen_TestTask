using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Queries.Authors;

public sealed record GetAuthorQuery(Guid Id) : IRequest<AuthorDto>; 