using System.ComponentModel.DataAnnotations;

namespace todo_app.models;

public class Users
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(100)]
    public required string Name { get; set; }


    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public required string Password { get; set; }

    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly UpdatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}