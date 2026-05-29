using Microsoft.EntityFrameworkCore;
using todo_app.models;
using todo_app.Models;

namespace todo_app.Data;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Users> Users { get; set; }
}
