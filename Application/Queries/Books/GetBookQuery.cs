using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Queries.Books;

public sealed record GetBookQuery(Guid Id) : IRequest<BookDto>;