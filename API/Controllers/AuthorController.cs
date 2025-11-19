using Business.DTOs;
using Business.Interfaces;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet(Name = "GetAllAuthors")]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
    {
        var authors = await _authorService.GetAllAuthorsAsync();
        var result = authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            Books = a.BookAuthors?.Select(ba => new BookSimpleDto
            {
                Id = ba.Book!.Id,
                Title = ba.Book.Title,
                ISBN = ba.Book.ISBN
            }).ToList()
        });

        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetAuthorById")]
    public async Task<ActionResult<AuthorDto>> GetById(int id)
    {
        var author = await _authorService.GetAuthorByIdAsync(id);
        if (author == null) return NotFound();

        var result = new AuthorDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Books = author.BookAuthors?.Select(ba => new BookSimpleDto
            {
                Id = ba.Book!.Id,
                Title = ba.Book.Title,
                ISBN = ba.Book.ISBN
            }).ToList()
        };

        return Ok(result);
    }

    [HttpPost(Name = "CreateAuthor")]
    public async Task<ActionResult<AuthorDto>> Create([FromBody] AuthorDto authorDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var author = new Author
        {
            FirstName = authorDto.FirstName,
            LastName = authorDto.LastName
        };

        await _authorService.AddAuthorAsync(author);

        authorDto.Id = author.Id;

        return CreatedAtRoute("GetAuthorById", new { id = author.Id }, authorDto);
    }

    [HttpPut("{id}", Name = "UpdateAuthor")]
    public async Task<IActionResult> Update(int id, [FromBody] AuthorDto authorDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != authorDto.Id) return BadRequest();

        var existing = await _authorService.GetAuthorByIdAsync(id);
        if (existing == null) return NotFound();

        existing.FirstName = authorDto.FirstName;
        existing.LastName = authorDto.LastName;

        await _authorService.UpdateAuthorAsync(existing);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteAuthor")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _authorService.GetAuthorByIdAsync(id);
        if (existing == null) return NotFound();

        await _authorService.DeleteAuthorAsync(id);
        return NoContent();
    }
}

