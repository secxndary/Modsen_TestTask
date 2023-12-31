using Application.Commands.Authentication;
using Application.Handlers.Authentication;
using Application.Queries.Authentication;
using BookLibrary.Presentation.Filters.ActionFilters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.AuthenticationDtos;

namespace BookLibrary.Presentation.Controllers.Authentication;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController(ISender sender) : ControllerBase
{
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto user)
    {
        var result = await sender.Send(new RegisterUserCommand(user));

        if (result.Succeeded) 
            return StatusCode(201);

        foreach (var error in result.Errors)
            ModelState.TryAddModelError(error.Code, error.Description);
        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        if (!await sender.Send(new ValidateUserQuery(user)))
            return Unauthorized(string.Empty);

        var tokenDto = await sender.Send(new CreateTokenCommand(PopulateExpiration: true));
        return Ok(tokenDto);
    }
}