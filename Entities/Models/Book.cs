namespace Entities.Models;

public class Book
{
    public Guid Id { get; set; }
    public string? Isbn { get; set; }
    public string? Description { get; set; }
    public DateTime BorrowDateStart { get; set; }
    public DateTime BorrowDateEnd { get; set; }
    
    public Guid? AuthorId { get; set; }
    public Author? Author { get; set; }
    
    public IEnumerable<Genre>? Genres { get; set; }
}