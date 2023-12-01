using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly AppContext _context;

    public MessageController(AppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
    {
        return await _context.Messages.ToListAsync();
    }

    // Additional CRUD methods (GET by ID, POST, PUT, DELETE) can be added here
}
