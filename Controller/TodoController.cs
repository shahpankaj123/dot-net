using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_app.Data;
using todo_app.Dtos;
using todo_app.Models;

namespace todo_app.Controller;


[ApiController]
[Route("web/api/v1/todos/")]
public class TodoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TodoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetTodo")]
    public async Task<IActionResult> GetTodos()
    {
        var todos = await _context.Todos.Include(t => t.Genre)
                                        .Include(t => t.User)
                                        .ToListAsync();
        return Ok(todos);
    }

    [HttpPost("CreateTodo")]
    public async Task<IActionResult> CreateTodo(CreateTodo todo)
    {
        if (todo is null) return BadRequest(new CommonResponse(400, "Data Not Found"));

        var genre = await _context.Genres.FindAsync(todo.genreId);
        if (genre is null) return BadRequest(new CommonResponse(400, "Genre Not Found"));

        var user = await _context.Users.FindAsync(todo.userId);
        if (user is null) return BadRequest(new CommonResponse(400, "User Not Found"));

        Todo newTodo = new Todo
        {
            Title = todo.title,
            Description = todo.description,
            IsCompleted = false,
            Genre = genre,
            User = user,
            UserId = todo.userId,
            GenreId = todo.genreId
        };

        _context.Todos.Add(newTodo);
        await _context.SaveChangesAsync();

        return Ok(newTodo);
    }

}