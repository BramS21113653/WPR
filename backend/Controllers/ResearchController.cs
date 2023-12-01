using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    // GET: /Research/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Research>> GetResearch(string id)
    {
        var research = await _context.Researches.FindAsync(id);

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

    // Additional methods (PUT, DELETE) can be added here
}
