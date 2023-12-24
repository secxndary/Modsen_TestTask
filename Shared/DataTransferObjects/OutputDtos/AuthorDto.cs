namespace Shared.DataTransferObjects.OutputDtos;

public record AuthorDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
}