namespace Entities.Exceptions.NotFound;

public class GenreNotFoundException(Guid id) : NotFoundException($"Genre with id: {id} doesn't exist in the database");