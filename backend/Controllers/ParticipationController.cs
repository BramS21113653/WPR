using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ParticipationController : ControllerBase
{
    private readonly AppContext _context;

    public ParticipationController(AppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Participation>>> GetParticipations()
    {
        return await _context.Participations.ToListAsync();
    }

    // GET: /Participation/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Participation>> GetParticipation(string id)
    {
        var participation = await _context.Participations.FindAsync(id);

        if (participation == null)
        {
            return NotFound();
        }

        return participation;
    }

    // Additional CRUD methods (GET by ID, POST, PUT, DELETE) can be added here
}
