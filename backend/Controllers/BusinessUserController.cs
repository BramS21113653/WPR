using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.JsonPatch;

[ApiController]
[Route("[controller]")]
public class BusinessUserController : ControllerBase
{
    private readonly AppContext _context;
    private readonly ILogger<BusinessUserController> _logger;

    public BusinessUserController(AppContext context, ILogger<BusinessUserController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("profile"), Authorize]
    public async Task<ActionResult<BusinessUser>> GetProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
        {
            _logger.LogWarning("User ID claim not found in the token.");
            return NotFound("User ID claim not found in the token.");
        }

        if (!Guid.TryParse(userId, out Guid guidId))
        {
            _logger.LogWarning($"Invalid user ID format: {userId}");
            return BadRequest("Invalid user ID format.");
        }

        _logger.LogInformation($"Attempting to retrieve profile for user ID: {userId}");

        var businessUser = await _context.BusinessUsers.FindAsync(guidId);

        if (businessUser == null)
        {
            _logger.LogWarning($"Business user not found with ID: {userId}");
            return NotFound($"Business user not found with ID: {userId}");
        }

        return businessUser;
    }

    [HttpPatch("{id:guid}"), Authorize]
    public async Task<IActionResult> UpdateBusinessUser(Guid id, JsonPatchDocument<BusinessUser> patchDoc)
    {
        if (!Guid.TryParse(id.ToString(), out Guid userId))
        {
            return BadRequest("Invalid user ID format.");
        }

        var businessUser = await _context.BusinessUsers.FindAsync(id);
        if (businessUser == null)
        {
            return NotFound($"Business user not found with ID: {id}");
        }

        patchDoc.ApplyTo(businessUser, error => 
        {
            ModelState.AddModelError(error.Operation.path, error.ErrorMessage);
        });

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Entry(businessUser).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.BusinessUsers.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

[HttpDelete("{id:guid}"), Authorize]
public async Task<IActionResult> DeleteBusinessUser(Guid id)
{
    var businessUser = await _context.BusinessUsers
                                    .Include(bu => bu.Chats) // Include related Chats
                                    .FirstOrDefaultAsync(bu => bu.Id == id);

    if (businessUser == null)
    {
        _logger.LogWarning($"Business user not found with ID: {id}");
        return NotFound($"Business user not found with ID: {id}");
    }

    // Set PanelMemberId to null for related Chats
    foreach (var chat in businessUser.Chats)
    {
        chat.PanelMemberId = null;
    }

    _context.BusinessUsers.Remove(businessUser);

    try
    {
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Successfully deleted business user with ID: {id}");
        return NoContent();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, $"Error occurred while deleting business user with ID: {id}");
        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the user.");
    }
}
}
