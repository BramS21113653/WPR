using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;

[ApiController]
[Route("[controller]")]
public class PanelMemberController : ControllerBase
{
    private readonly AppContext _context;
    private readonly ILogger<PanelMemberController> _logger;

    public PanelMemberController(AppContext context, ILogger<PanelMemberController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PanelMember>> GetPanelMemberById(Guid id)
    {
        _logger.LogInformation($"Attempting to retrieve panel member with ID: {id}");

        var panelMember = await _context.PanelMembers
            // .Include(pm => pm.ParentGuardian)
            .FirstOrDefaultAsync(pm => pm.Id == id); // Directly compare Guids

        if (panelMember == null)
        {
            _logger.LogWarning($"Panel member not found with ID: {id}");
            return NotFound($"Panel member not found with ID: {id}");
        }

        return panelMember;
    }

    //todo
 [HttpGet("profile"), Authorize]
public async Task<ActionResult<PanelMember>> GetProfile()
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

   bool userExists = await _context.PanelMembers.AnyAsync(pm => pm.Id == guidId);

   if (!userExists)
   {
       _logger.LogWarning($"Panel member not found with ID: {userId}");
       return NotFound($"Panel member not found with ID: {userId}");
   }

   var panelMember = await _context.PanelMembers
       .FirstOrDefaultAsync(pm => pm.Id == guidId);

   return panelMember;
}


[HttpPut("{id:guid}"), Authorize]
public async Task<IActionResult> PutPanelMember(Guid id, JsonPatchDocument<PanelMember> patchDoc)
{
  if (!PanelMemberExists(id))
  {
      return NotFound();
  }

  var panelMember = await _context.PanelMembers.FindAsync(id);

  patchDoc.ApplyTo(panelMember, error =>
  {
      ModelState.TryAddModelError(string.Empty, error.ErrorMessage);
  });

  if (!ModelState.IsValid)
  {
      return BadRequest(ModelState);
  }

  try
  {
      await _context.SaveChangesAsync();
  }
  catch (DbUpdateConcurrencyException)
  {
      if (!PanelMemberExists(id))
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
    private bool PanelMemberExists(Guid id)
    {
        return _context.PanelMembers.Any(e => e.Id == id);
    }

    [HttpDelete("{id:guid}"), Authorize]
    public async Task<IActionResult> DeletePanelMember(Guid id)
    {
        var panelMember = await _context.PanelMembers.FindAsync(id);
        if (panelMember == null)
        {
            return NotFound();
        }

        _context.PanelMembers.Remove(panelMember);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<PanelMember>>> GetPanelMembers()
    {
        return await _context.PanelMembers.ToListAsync();
    }
}