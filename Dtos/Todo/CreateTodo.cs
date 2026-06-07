using System.ComponentModel.DataAnnotations;

namespace todo_app.Dtos;

public record CreateTodo(
    [Required][MaxLength(100)]
    string title,
    [Required]
    string description,
    [Required]
    Guid genreId,
    [Required]
    Guid userId
);
