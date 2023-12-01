using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class PanelMemberController : ControllerBase
{
    private readonly AppContext _context;

    public PanelMemberController(AppContext context)
    {
        _context = context;
    }

    // GET: /PanelMember
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PanelMember>>> GetPanelMembers()
    {
        return await _context.PanelMembers.ToListAsync();
    }

    // GET: /PanelMember/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PanelMember>> GetPanelMember(string id)
    {
        var panelMember = await _context.PanelMembers.FindAsync(id);

        if (panelMember == null)
        {
            return NotFound();
        }

        return panelMember;
    }

    // POST: /PanelMember
    [HttpPost]
    public async Task<ActionResult<PanelMember>> PostPanelMember(PanelMember panelMember)
    {
        _context.PanelMembers.Add(panelMember);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPanelMember", new { id = panelMember.Id }, panelMember);
    }

    // Additional methods (PUT, DELETE) can be added here
}
