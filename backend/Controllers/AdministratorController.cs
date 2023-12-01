using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class AdministratorController : ControllerBase
{
    private readonly AppContext _context;

    public AdministratorController(AppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Administrator>>> GetAdministrators()
    {
        return await _context.Administrators.ToListAsync();
    }

    // Additional CRUD methods (GET by ID, POST, PUT, DELETE) can be added here
}
