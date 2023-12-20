using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class ApplicationUserController : ControllerBase
{
    private readonly AppContext _context;
    private readonly IUserService _userService; // Assuming you have a user service

    public ApplicationUserController(AppContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetApplicationUsers()
    {
        return await _context.Users.ToListAsync();
    }
    
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest model)
    {
        var result = await _userService.Register(model);
        if (result.Succeeded)
        {
            return Ok(new { message = "Registration successful" });
        }

        // If the registration was not successful, send back the list of errors
        var errors = result.Errors.Select(e => e.Description).ToList();
        return BadRequest(new { errors });
    }

[AllowAnonymous]
[HttpPost("authenticate")]
public async Task<IActionResult> Authenticate(AuthenticateRequest model)
{
    var response = await _userService.Authenticate(model);
    if (response != null)
    {
        return Ok(response);
    }
    // Return an appropriate response, e.g. Unauthorized
    return Unauthorized(new { message = "Authentication failed" });
}

    // Additional CRUD methods (GET by ID, POST, PUT, DELETE) can be added here
}
