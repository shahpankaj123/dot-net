using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_app.Data;
using todo_app.Dtos;
using todo_app.Dtos.Genre;
using todo_app.Models;

namespace todo_app.Controller;


[ApiController]
[Route("web/api/v1/")]
public class GenreController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GenreController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("Getgenre")]
    public async Task<IActionResult> Getgenres()
    {
        var todos = await _context.Genres.ToListAsync();
        return Ok(todos);
    }

    [HttpPost("CreateGenre")]
    public async Task<IActionResult> CreateGenre(CreateGenre gen)
    {
        if (gen is null)
        {
            return BadRequest(new CommonResponse(400, "Data Not Found"));
        }

        bool genreExists = await _context.Genres
        .AnyAsync(x => x.Name.ToLower() == gen.genreName.ToLower());

        if (genreExists)
        {
            return BadRequest(new CommonResponse(400, "Genre already exists"));
        }

        Genre genre = new Genre
        {
            Name = gen.genreName
        };

        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();

        return Ok(genre);
    }

    [HttpGet("GetGenreById")]
    public async Task<IActionResult> GetGenreById([FromQuery] Guid genreId)
    {
        var genre = await _context.Genres.FindAsync(genreId);

        if (genre == null)
        {
            return NotFound(new CommonResponse(404, "Data Not Found"));
        }

        return Ok(genre);
    }


    [HttpPost("DeleteGenre")]
    public async Task<IActionResult> DeleteGenre(DeleteGenreRequest gen)
    {
        var genre = await _context.Genres.FindAsync(gen.genreId);
        if (genre == null)
        {
            return NotFound(new CommonResponse(400, "Data Not Found"));
        }
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
        return Ok(new CommonResponse(200, "Data Deleted Successfully"));
    }
}