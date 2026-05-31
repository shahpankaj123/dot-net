
namespace todo_app.Controller;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_app.Data;
using todo_app.Dtos;
using todo_app.Dtos.Users;
using todo_app.models;

[ApiController]
[Route("web/api/v1/users/")]
public class UserController : ControllerBase
{

    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext c)
    {
        _context = c;
    }

    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> getAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser(CreateUsers usr)
    {
        var emailExists = await _context.Users
            .AnyAsync(u => u.Email == usr.email);

        if (emailExists)
        {
            return BadRequest(new CommonResponse(400, "Email Already Exists!"));
        }

        Users us = new Users
        {
            Name = usr.name,
            Email = usr.email,
            Password = usr.password
        };

        _context.Users.Add(us);
        await _context.SaveChangesAsync();

        return Ok(new CommonResponse(201, "User created successfully"));
    }


    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
    {
        var usr = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);

        if (usr == null)
        {
            return NotFound(new CommonResponse(404, "User Not Found"));
        }

        return Ok(usr);
    }

}