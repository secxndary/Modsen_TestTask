namespace Shared.DataTransferObjects.Contracts;

public record BookForManipulationDto
{
    public string? Isbn { get; init; }
    public string? Description { get; init; }
    public DateTime BorrowDateStart { get; init; }
    public DateTime BorrowDateEnd { get; init; }
    public Guid? AuthorId { get; init; }
}