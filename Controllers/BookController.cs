using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.DTOs;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Services;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
       
       private readonly IMapper _mapper;
       private readonly IBookService _bookService;


        public BookController( IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        [HttpGet]

      public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var book = await _bookService.GetAllBooks();
            if (!book.Any())
            {
                return NotFound("No books found");
            }
            return Ok(book);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var book = await _bookService.GetById(id);
            if (book == null)
                return NotFound("Id not found");

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createBook = await _bookService.CreateBook(book);

            return CreatedAtAction(nameof(GetBookById), new { id = createBook.Id }, createBook);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<BookDto>> EditBook(int id, Book Updatedbook)
        {
            var book = await _bookService.UpdateBook(id, Updatedbook);
            if (book == null)
                return NotFound("Book Not found");

       
       
            return Ok(book);

        }


        [HttpDelete("{id:int}")]

        public async Task<ActionResult<BookDto>> DeleteBook(int id)
        {
            var book = await _bookService.DeleteById(id);

            return NoContent();
        }
        

    }
}
