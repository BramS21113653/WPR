using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Required for IFormFile
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO; // Required for MemoryStream

[ApiController]
[Route("[controller]")]
public class ResearchController : ControllerBase
{
    private readonly AppContext _context;

    public ResearchController(AppContext context)
    {
        _context = context;
    }

    private string ConvertToBase64(byte[] imageData)
{
    return imageData == null ? null : Convert.ToBase64String(imageData);
}

    // GET: /Research
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetResearches()
    {
        var researches = await _context.Researches.ToListAsync();
        return researches.Select(r => new 
        {
            r.Id,
            r.Title,
            r.Description,
            ImageData = ConvertToBase64(r.ImageData)
        }).ToList();
    }

    // GET: /Research/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<object>> GetResearch(string id)
    {
        var research = await _context.Researches.FindAsync(id);

        if (research == null)
        {
            return NotFound();
        }

        return new
        {
            research.Id,
            research.Title,
            research.Description,
            ImageData = ConvertToBase64(research.ImageData)
        };
    }

    // POST: /Research
    // POST: /Research
    [HttpPost]
    public async Task<ActionResult<Research>> PostResearch([FromForm] Research research, IFormFile imageFile)
    {
        if (imageFile != null && imageFile.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                research.ImageData = memoryStream.ToArray();
            }
        }

        _context.Researches.Add(research);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetResearch", new { id = research.Id }, research);
    }


    // PUT: /Research/{id}
    // DELETE: /Research/{id}
    // ... other methods ...

    // POST: /Research/like/{researchId}
    [HttpPost("like/{researchId}")]
    public async Task<IActionResult> LikeResearch(string researchId)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId == null || !Guid.TryParse(userId, out Guid guidUserId))
        {
            return Unauthorized();
        }

        var research = await _context.Researches.FindAsync(researchId);
        if (research == null)
        {
            return NotFound();
        }

        var alreadyLiked = await _context.ResearchInterests.AnyAsync(ri => ri.PanelMemberId == guidUserId && ri.ResearchId == researchId);
        if (!alreadyLiked)
        {
            var researchInterest = new ResearchInterest
            {
                PanelMemberId = guidUserId,
                ResearchId = researchId
            };

            _context.ResearchInterests.Add(researchInterest);
            await _context.SaveChangesAsync();
        }

        return Ok();
    }

    // POST: /Research/unlike/{researchId}
    [HttpPost("unlike/{researchId}")]
    public async Task<IActionResult> UnlikeResearch(string researchId)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId == null || !Guid.TryParse(userId, out Guid guidUserId))
        {
            return Unauthorized();
        }

        var researchInterest = await _context.ResearchInterests.FirstOrDefaultAsync(ri => ri.PanelMemberId == guidUserId && ri.ResearchId == researchId);
        if (researchInterest != null)
        {
            _context.ResearchInterests.Remove(researchInterest);
            await _context.SaveChangesAsync();
        }

        return Ok();
    }
}
