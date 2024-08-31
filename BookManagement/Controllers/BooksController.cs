using BookManagement.Models;
using BookManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddBook(BookDTO bookdto)
        //{
        //    var book = new Book
        //    {
        //        BookName = bookdto.BookName,
        //        Author = bookdto.Author,
        //        BookPrice = bookdto.BookPrice
        //    };

        //    await _bookService.Add(book);
        //    return Created();
        //}

        //[HttpPut("BookID")]
        //public async Task<IActionResult> EditBook(int BookID, BookDTO bookdto)
        //{
        //    var book = new BookDTO
        //    {
        //        BookName = bookdto.BookName,
        //        Author = bookdto.Author,
        //        BookPrice = bookdto.BookPrice
        //    };

        //    await _bookService.Edit(BookID, book);
        //    return NoContent();
        //}

        //[HttpDelete("BookID")]
        //public async Task<IActionResult> DeleteBook(int BookID)
        //{
        //    await _bookService.Delete(BookID);
        //    return NoContent();
        //}

        //[HttpGet("BookID")]
        //public async Task<IActionResult> GetBookByID(int BookID)
        //{
        //    var book = await _bookService.GetById(BookID);

        //    if (book == null)
        //        return BadRequest();

        //    return Ok(book);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllBook()
        //{
        //    var book = await _bookService.GetAll();

        //    if (book == null)
        //        return NotFound();

        //    return Ok(book);
        //}

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            _logger.LogInformation("GetBooks endpoint called from backend server");
            return await _bookService.GetAll();
        }

        [HttpGet("BookID")]
        public async Task<Book> GetBookByID(int BookID)
        {
            _logger.LogInformation("GetBookByID endpoint called from backend server");
            _logger.LogDebug($"Getting bookID {BookID}");
            return await _bookService.GetById(BookID);
        }

        [HttpPost]
        public async Task AddBook(BookDTO bookdto)
        {
            _logger.LogInformation("AddBook endpoint called from backend server");
            var book = new Book
            {
                BookName = bookdto.BookName,
                Author = bookdto.Author,
                BookPrice = bookdto.BookPrice
            };

            await _bookService.Add(book);
        }

        [HttpDelete("BookID")]
        public async Task DeleteBook(int BookID)
        {
            _logger.LogInformation("DeleteBook endpoint called from backend server");
            _logger.LogDebug($"Deleting bookID {BookID}");
            await _bookService.Delete(BookID);
        }

        [HttpPut("BookID")]
        public async Task EditBook(int BookID, BookDTO bookdto)
        {
            _logger.LogInformation("EditBook endpoint called from backend server");
            var book = new BookDTO
            {
                BookName = bookdto.BookName,
                Author = bookdto.Author,
                BookPrice = bookdto.BookPrice
            };

            await _bookService.Edit(BookID, book);
        }
    }
}
