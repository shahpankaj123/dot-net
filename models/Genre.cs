namespace todo_app.Models;

public class Genre
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }

    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly UpdatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}
