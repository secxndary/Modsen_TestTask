using MediatR;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Application.Commands.Authors;

public sealed record UpdateAuthorCommand(Guid Id, AuthorForUpdateDto AuthorForUpdate) : IRequest<AuthorDto>;