using Application.Commands.Authors;
using Application.Queries.Authors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace BookLibrary.Presentation.Controllers;

[ApiController]
[Authorize]
[Route("api/authors")]
public class AuthorsController(ISender sender) : ControllerBase
{
    [HttpGet(Name = "GetAllAuthors")]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await sender.Send(new GetAllAuthorsQuery());
        return Ok(authors);
    }

    [HttpGet("{id:guid}", Name = "GetAuthor")]
    public async Task<IActionResult> GetAuthor(Guid id)
    {
        var authors = await sender.Send(new GetAuthorQuery(id));
        return Ok(authors);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto author)
    {
        var createdAuthor = await sender.Send(new CreateAuthorCommand(author));
        return CreatedAtRoute("GetAuthor", new {createdAuthor.Id}, createdAuthor);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] AuthorForUpdateDto author)
    {
        var updatedAuthor = await sender.Send(new UpdateAuthorCommand(id, author));
        return Ok(updatedAuthor);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        await sender.Send(new DeleteAuthorCommand(id));
        return NoContent();
    }
}