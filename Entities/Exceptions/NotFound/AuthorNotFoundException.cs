namespace Entities.Exceptions.NotFound;

public class AuthorNotFoundException(Guid id) : NotFoundException($"Author with id: {id} doesn't exist in the database");