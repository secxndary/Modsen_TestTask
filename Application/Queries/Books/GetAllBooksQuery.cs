using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Queries.Books;

public sealed record GetAllBooksQuery : IRequest<IEnumerable<BookDto>>;
