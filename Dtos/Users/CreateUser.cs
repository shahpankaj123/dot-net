using System.ComponentModel.DataAnnotations;

namespace todo_app.Dtos.Users;




public record CreateUsers(

    [Required]
    string name,

    [Required][EmailAddress]
    string email,

    [Required]
    string password



);