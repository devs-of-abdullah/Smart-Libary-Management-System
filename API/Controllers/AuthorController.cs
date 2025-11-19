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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();

            var result = authors.Select(a => new AuthorDto
            { Id = a.Id,
                FullName = a.FirstName + " " + a.LastName,
                BirthYear = a.BirthYear,
            });
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(int id)
        {
            var resutl = await _authorService.GetAuthorByIdAsync(id);
            return Ok(resutl);
        }
        [HttpPost]
        public async Task<ActionResult> AddAuthor(CreateAuthorDto dto)
        {
            var Author = new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthYear = dto.BirthYear,

            };

            await _authorService.AddAuthorAsync(Author);
            return Ok(Author);
        }

        [HttpPut] 
        public async Task<ActionResult> UpdateAuthorById(int id, UpdateAuthorDto dto)
        {
            if(id != dto.Id)
                return BadRequest("ID not exists.");

            var existing = await _authorService.GetAuthorByIdAsync(id);
            if (existing == null) return NotFound("Book not found.");


            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            existing.BirthYear = dto.BirthYear;


            await _authorService.UpdateAuthorAsync(existing);

            return NoContent();




        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthorAsync(int id )
        {
                var a = _authorService.GetAuthorByIdAsync(id);
            if (a == null) return BadRequest("Author not found");


            await _authorService.DeleteAuthorAsync(id);

            return NoContent();
        }
    }
}
