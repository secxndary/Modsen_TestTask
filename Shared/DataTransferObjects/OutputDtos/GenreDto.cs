namespace Shared.DataTransferObjects.OutputDtos;

public record GenreDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}