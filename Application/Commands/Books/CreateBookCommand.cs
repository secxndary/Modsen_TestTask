using MediatR;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Commands.Books;

public sealed record CreateBookCommand(BookForCreationDto Book) : IRequest<BookDto>;