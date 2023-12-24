namespace Entities.Models;

public class Author
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    public IEnumerable<Book>? Books { get; set; }
}