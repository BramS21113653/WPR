using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class BusinessUserController : ControllerBase
{
    private readonly AppContext _context;

    public BusinessUserController(AppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusinessUser>>> GetBusinessUsers()
    {
        return await _context.BusinessUsers.ToListAsync();
    }

    // Additional CRUD methods (GET by ID, POST, PUT, DELETE) can be added here
}
