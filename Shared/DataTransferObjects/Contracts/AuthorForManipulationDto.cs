namespace Shared.DataTransferObjects.Contracts;

public record AuthorForManipulationDto
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}