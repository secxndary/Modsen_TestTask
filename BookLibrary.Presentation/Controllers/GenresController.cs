using Application.Commands.Genres;
using Application.Queries.Genres;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace BookLibrary.Presentation.Controllers;

[ApiController]
[Authorize]
[Route("api/genres")]
public class GenresController(ISender sender) : ControllerBase
{
    [HttpGet(Name = "GetAllGenres")]
    public async Task<IActionResult> GetAllGenres()
    {
        var genres = await sender.Send(new GetAllGenresQuery());
        return Ok(genres);
    }

    [HttpGet("{id:guid}", Name = "GetGenre")]
    public async Task<IActionResult> GetGenre(Guid id)
    {
        var genres = await sender.Send(new GetGenreQuery(id));
        return Ok(genres);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] GenreForCreationDto genre)
    {
        var createdGenre = await sender.Send(new CreateGenreCommand(genre));
        return CreatedAtRoute("GetGenre", new {createdGenre.Id}, createdGenre);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateGenre(Guid id, [FromBody] GenreForUpdateDto genre)
    {
        var updatedGenre = await sender.Send(new UpdateGenreCommand(id, genre));
        return Ok(updatedGenre);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteGenre(Guid id)
    {
        await sender.Send(new DeleteGenreCommand(id));
        return NoContent();
    }
}