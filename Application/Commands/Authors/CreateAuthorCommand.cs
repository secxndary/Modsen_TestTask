using MediatR;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Commands.Authors;

public sealed record CreateAuthorCommand(AuthorForCreationDto Author) : IRequest<AuthorDto>;