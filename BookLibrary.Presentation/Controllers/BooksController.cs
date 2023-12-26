using Application.Commands.Books;
using Application.Queries.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace BookLibrary.Presentation.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController(ISender sender) : ControllerBase
{
    [HttpGet(Name = "GetAllBooks")]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await sender.Send(new GetAllBooksQuery());
        return Ok(books);
    }

    [HttpGet("{id:guid}", Name = "GetBook")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        var books = await sender.Send(new GetBookQuery(id));
        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] BookForCreationDto book)
    {
        var createdBook = await sender.Send(new CreateBookCommand(book));
        return CreatedAtRoute("GetBook", new {createdBook.Id}, createdBook);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookForUpdateDto book)
    {
        var updatedBook = await sender.Send(new UpdateBookCommand(id, book));
        return Ok(updatedBook);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        await sender.Send(new DeleteBookCommand(id));
        return NoContent();
    }
}