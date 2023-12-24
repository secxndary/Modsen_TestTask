namespace Shared.DataTransferObjects.Contracts;

public record GenreForManipulationDto
{
    public string? Name { get; init; }
    public string? Description { get; init; }
}