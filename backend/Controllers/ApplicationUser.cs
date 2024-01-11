using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
    

    [HttpGet("userinfo")]
    [Authorize]
    public async Task<IActionResult> GetUserInfo()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return Unauthorized(new { message = "Invalid token" });
        }

        if (!Guid.TryParse(userIdString, out Guid userId))
        {
            return BadRequest(new { message = "Invalid user ID format." });
        }

        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        // Create a user info object to return. Avoid sending sensitive data.
        var userInfo = new { user.Id, user.UserName, user.Email };
        return Ok(userInfo);
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser([FromBody] RegisterRequest model)
    {
        var result = await _userService.Register(model);
        if (result.Succeeded)
        {
            return Ok("User registered as PanelMember");
        }
        else
        {
            return BadRequest(result.Errors);
        }
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
