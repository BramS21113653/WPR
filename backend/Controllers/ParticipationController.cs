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

    // Additional CRUD methods (GET by ID, POST, PUT, DELETE) can be added here
}
