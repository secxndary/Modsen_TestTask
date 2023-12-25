using MediatR;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Application.Commands.Books;

public sealed record UpdateBookCommand(Guid Id, BookForUpdateDto BookForUpdate) : IRequest<BookDto>;