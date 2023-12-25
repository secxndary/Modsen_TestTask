using Application.Queries.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Presentation.Controllers;

[ApiController]
[Route("books")]
public class BooksController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _sender.Send(new GetAllBooksQuery());
        return Ok(books);
    }
}