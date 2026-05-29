using todo_app.models;

namespace todo_app.Models;



public class Todo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; } = false;

    public required Genre Genre { get; set; }

    public required Users User { get; set; }

    public Guid UserId { get; set; }

    public Guid GenreId { get; set; }

    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly UpdatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}