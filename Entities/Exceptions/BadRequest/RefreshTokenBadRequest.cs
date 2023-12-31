namespace Entities.Exceptions.BadRequest;

public class RefreshTokenBadRequest() : BadRequestException("Invalid client request. The TokenDto has invalid values.");