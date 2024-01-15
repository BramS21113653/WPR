using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ResearchController : ControllerBase
{
   private readonly AppContext _context;

   public ResearchController(AppContext context)
   {
       _context = context;
   }

   // GET: /Research
   [HttpGet]
   public async Task<ActionResult<IEnumerable<Research>>> GetResearches()
   {
       return await _context.Researches.ToListAsync();
   }

   // GET: /Research/{id}
   [HttpGet("{id}")]
   public async Task<ActionResult<Research>> GetResearch(string id)
   {
       if (!Guid.TryParse(id, out Guid guidId))
       {
           return BadRequest("Invalid ID format.");
       }

       var research = await _context.Researches.FindAsync(guidId);

       if (research == null)
       {
           return NotFound();
       }

       return research;
   }

   // POST: /Research
   [HttpPost]
   public async Task<ActionResult<Research>> PostResearch(Research research)
   {
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
       if (!Guid.TryParse(researchId, out Guid guidResearchId))
       {
           return BadRequest("Invalid ResearchId format.");
       }

       var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
       if (userId == null || !Guid.TryParse(userId, out Guid guidUserId))
       {
           return Unauthorized();
       }

       var research = await _context.Researches.FindAsync(guidResearchId);
       if (research == null)
       {
           return NotFound();
       }

       var alreadyLiked = await _context.ResearchInterests.AnyAsync(ri => ri.PanelMemberId == guidUserId && ri.ResearchId == guidResearchId);
       if (!alreadyLiked)
       {
           var researchInterest = new ResearchInterest
           {
               PanelMemberId = guidUserId,
               ResearchId = guidResearchId
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
       if (!Guid.TryParse(researchId, out Guid guidResearchId))
       {
           return BadRequest("Invalid ResearchId format.");
       }

       var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
       if (userId == null || !Guid.TryParse(userId, out Guid guidUserId))
       {
           return Unauthorized();
       }

       var researchInterest = await _context.ResearchInterests.FirstOrDefaultAsync(ri => ri.PanelMemberId == guidUserId && ri.ResearchId == guidResearchId);
       if (researchInterest != null)
       {
           _context.ResearchInterests.Remove(researchInterest);
           await _context.SaveChangesAsync();
       }

       return Ok();
   }
}
