using Application.Commands.Authentication;
using BookLibrary.Presentation.Filters.ActionFilters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.AuthenticationDtos;

namespace BookLibrary.Presentation.Controllers.Authentication;

[ApiController]
[Route("api/token")]
public class TokenController(ISender sender) : ControllerBase
{
    [HttpPost("refresh")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var tokenDtoRefreshed = await sender.Send(new RefreshTokenCommand(tokenDto));
        return Ok(tokenDtoRefreshed);
    }
}
