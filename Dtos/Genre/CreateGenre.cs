using System.ComponentModel.DataAnnotations;

namespace todo_app.Dtos.Genre;


public record CreateGenre(
    [Required][StringLength(50)]
    String genreName

);