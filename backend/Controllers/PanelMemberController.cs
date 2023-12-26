using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
        .Include(pm => pm.ParentGuardian)
        .FirstOrDefaultAsync(pm => pm.Id == id.ToString()); // Convert Guid to string

    if (panelMember == null)
    {
        _logger.LogWarning($"Panel member not found with ID: {id}");
        return NotFound($"Panel member not found with ID: {id}");
    }

    return panelMember;
}


    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<PanelMember>>> GetPanelMembers()
    {
        return await _context.PanelMembers.ToListAsync();
    }

    // // [HttpGet, Authorize]
    // [HttpGet]
    // public async Task<ActionResult<PanelMember>> GetPanelMember()
    // {
    //     // Log the user ID obtained from the token for debugging purposes.
    //     string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //     _logger.LogInformation($"Attempting to retrieve panel member for user ID: {userId}");

    //     if (string.IsNullOrEmpty(userId))
    //     {
    //         _logger.LogWarning("User ID claim not found in the token.");
    //         return NotFound("User ID claim not found in the token.");
    //     }

    //     var panelMember = await _context.PanelMembers.Include(pm => pm.ParentGuardian).SingleOrDefaultAsync(pm => pm.Id == userId);

    //     if (panelMember == null)
    //     {
    //         _logger.LogWarning($"Panel member not found for user ID: {userId}");
    //         return NotFound($"Panel member not found for user ID: {userId}");
    //     }

    //     return panelMember;
    // }

    // [HttpGet]
    // public async Task<ActionResult<PanelMember>> GetPanelMember()
    // {
    //     string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //     _logger.LogInformation($"Attempting to retrieve panel member for user ID: {userId}");

    //     if (string.IsNullOrEmpty(userId))
    //     {
    //         _logger.LogWarning("User ID claim not found in the token.");
    //         return NotFound("User ID claim not found in the token.");
    //     }

    //     var panelMember = await _context.Users.OfType<PanelMember>().Include(pm => pm.ParentGuardian).SingleOrDefaultAsync(pm => pm.Id == userId);

    //     if (panelMember == null)
    //     {
    //         _logger.LogWarning($"Panel member not found for user ID: {userId}");
    //         return NotFound($"Panel member not found for user ID: {userId}");
    //     }

    //     return panelMember;
    // }


// [HttpGet]
// public async Task<ActionResult<PanelMember>> GetPanelMember()
// {
//     string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//     _logger.LogInformation($"Attempting to retrieve panel member for user ID: {userId}");

//     if (string.IsNullOrEmpty(userId))
//     {
//         _logger.LogWarning("User ID claim not found in the token.");
//         return NotFound("User ID claim not found in the token.");
//     }

//     // Query for the PanelMember directly without checking Discriminator
//     var panelMember = await _context.Set<PanelMember>().Include(pm => pm.ParentGuardian).SingleOrDefaultAsync(pm => pm.Id == userId);

//     if (panelMember == null)
//     {
//         _logger.LogWarning($"Panel member not found for user ID: {userId}");
//         return NotFound($"Panel member not found for user ID: {userId}");
//     }

//     return panelMember;
// }

[HttpGet]
public async Task<ActionResult<PanelMember>> GetPanelMember()
{
    string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    _logger.LogInformation($"Attempting to retrieve panel member for user ID: {userId}");

    if (string.IsNullOrEmpty(userId))
    {
        _logger.LogWarning("User ID claim not found in the token.");
        return NotFound("User ID claim not found in the token.");
    }

    Guid parsedUserId;
    if (!Guid.TryParse(userId, out parsedUserId))
    {
        _logger.LogWarning($"User ID is not in a valid GUID format: {userId}");
        return NotFound("User ID is not a valid GUID.");
    }

    var panelMember = await _context.Users
        .OfType<PanelMember>()
        .Include(pm => pm.ParentGuardian)
        .SingleOrDefaultAsync(pm => pm.Id == parsedUserId.ToString());

    // Log the query for debugging.
    _logger.LogInformation(_context.Users.ToQueryString());

    if (panelMember == null)
    {
        _logger.LogWarning($"Panel member not found for user ID: {userId}");
        return NotFound($"Panel member not found for user ID: {userId}");
    }

    return panelMember;
}




    [HttpPost]
    public async Task<ActionResult<PanelMember>> PostPanelMember(PanelMember panelMember)
    {
        _context.PanelMembers.Add(panelMember);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPanelMember), new { id = panelMember.Id }, panelMember);
    }

    [HttpPut("{id}"), Authorize]
    public async Task<IActionResult> PutPanelMember(string id, PanelMember panelMember)
    {
        if (id != panelMember.Id)
        {
            return BadRequest();
        }

        _context.Entry(panelMember).State = EntityState.Modified;

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

    private bool PanelMemberExists(string id)
    {
        return _context.PanelMembers.Any(e => e.Id == id);
    }

    [HttpDelete("{id}"), Authorize]
    public async Task<IActionResult> DeletePanelMember(string id)
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
}
