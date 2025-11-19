

using API.DTOs;
using Business.Interfaces;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
       

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();

            var result = books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                
                PublicationYear = b.PublicationYear,
                CopiesTotal = b.CopiesTotal,
                CopiesAvailable = b.CopiesAvailable,
                GenreId = b.GenreId,
                PublisherId = b.PublisherId,
                Author = b.Author,
                Genre = b.Genre == null ? null : new GenreDto
                {
                    Id = b.Genre.Id,
                    Name = b.Genre.Name
                },

                Publisher = b.Publisher == null ? null : new PublisherDto
                {
                    Id = b.Publisher.Id,
                    Name = b.Publisher.Name
                },


                
            });

            return Ok(result);
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var b = await _bookService.GetBookByIdAsync(id);
            if (b == null) return NotFound("Book not found.");

            var dto = new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                PublicationYear = b.PublicationYear,
                CopiesTotal = b.CopiesTotal,
                CopiesAvailable = b.CopiesAvailable,
                GenreId = b.GenreId,
                PublisherId = b.PublisherId,
                Author = b.Author,
                Genre = b.Genre == null ? null : new GenreDto { Id = b.Genre.Id, Name = b.Genre.Name },
                Publisher = b.Publisher == null ? null : new PublisherDto { Id = b.Publisher.Id, Name = b.Publisher.Name },
                
            };

            return Ok(dto);
        }

     
        [HttpPost]
        public async Task<ActionResult> AddBook(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                ISBN = dto.ISBN,
               
                PublicationYear = dto.PublicationYear,
                CopiesTotal = dto.CopiesTotal,
                CopiesAvailable = dto.CopiesTotal,
                GenreId = dto.GenreId,
                AuthorId = dto.AuthorId,
                PublisherId = dto.PublisherId
            };

            await _bookService.AddBookAsync(book);

           

            return Ok(dto);
        }

     
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, UpdateBookDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID not exists.");

            var existing = await _bookService.GetBookByIdAsync(id);
            if (existing == null) return NotFound("Book not found.");

            existing.Title = dto.Title;
            existing.ISBN = dto.ISBN;
            existing.AuthorId = dto.AuthorId;
            existing.PublicationYear = dto.PublicationYear;
            existing.CopiesTotal = dto.CopiesTotal;
            existing.CopiesAvailable = dto.CopiesAvailable;
            existing.GenreId = dto.GenreId;
            existing.PublisherId = dto.PublisherId;

            await _bookService.UpdateBookAsync(existing);

            return NoContent();
        }

    
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var b = await _bookService.GetBookByIdAsync(id);
            if (b == null) return NotFound("Book not found.");

            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}

