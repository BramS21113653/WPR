using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ParentGuardianController : ControllerBase
{
    private readonly AppContext _context;

    public ParentGuardianController(AppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ParentGuardian>>> GetParentGuardians()
    {
        return await _context.ParentGuardians.ToListAsync();
    }

    // Additional CRUD methods (GET by ID, POST, PUT, DELETE) can be added here
}
