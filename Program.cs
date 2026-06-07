using Microsoft.EntityFrameworkCore;
using todo_app.Data;
using todo_app.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    )
);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


// Global error handling middleware
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new CommonResponse(500, ex.Message));
    }
}
);


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
