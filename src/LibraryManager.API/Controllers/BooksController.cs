using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public IActionResult Add(Book book)
        {
            _service.AddBook(book);
            return Ok();
        }

        [HttpDelete("remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            _service.RemoveBook(id);
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult Search(string query) =>
            Ok(_service.Search(query));

        [HttpPost("borrow/{id}")]
        public IActionResult Borrow(Guid id, [FromQuery] string user)
        {
            _service.BorrowBook(id, user);
            return Ok();
        }

        [HttpPost("return/{id}")]
        public IActionResult Return(Guid id)
        {
            _service.ReturnBook(id);
            return Ok();
        }

        [HttpGet("borrowed")]
        public IActionResult BorrowedBooks([FromQuery] string user) =>
            Ok(_service.GetBorrowedBooks(user));
    }
}