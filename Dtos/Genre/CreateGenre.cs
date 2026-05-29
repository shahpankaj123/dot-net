using System.ComponentModel.DataAnnotations;

namespace todo_app.Dtos;


public record CreateGenre(
    [Required][StringLength(50)]
    String genreName

);