using System.ComponentModel.DataAnnotations;

namespace todo_app.Dtos.Genre;

public record DeleteGenreRequest(

    [Required] Guid genreId
);