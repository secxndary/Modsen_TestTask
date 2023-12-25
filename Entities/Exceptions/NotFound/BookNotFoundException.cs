namespace Entities.Exceptions.NotFound;

public class BookNotFoundException(Guid id) : NotFoundException($"Book with id: {id} doesn't exist in the database");