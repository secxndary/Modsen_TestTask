namespace Shared.DataTransferObjects.OutputDtos;

public record BookDto
{
    public Guid Id { get; set; }
    public string? Isbn { get; set; }
    public string? Description { get; set; }
    public DateTime BorrowDateStart { get; set; }
    public DateTime BorrowDateEnd { get; set; }
}