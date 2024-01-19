using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly ChatService _chatService;
    private readonly AppContext _context;

    public ChatController(ChatService chatService, AppContext context)
    {
        _chatService = chatService;
        _context = context;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateChat([FromBody] ChatCreateModel model)
    {
        var chat = await _chatService.CreateChat(model.PanelMemberId, model.BusinessUserId, model.ResearchId);
        return Ok(chat);
    }

    // [HttpPost("send")]
    // public async Task<IActionResult> SendMessage([FromBody] SendMessageModel model)
    // {
    // if (model.BusinessUserId == null || model.ResearchId == null)
    // {
    //     return BadRequest("Both businessUserId and researchId must be provided.");
    // }

    // var message = await _chatService.SendMessage(model.ChatId, model.SenderId, model.Content, model.BusinessUserId, model.ResearchId);
    // return Ok(message);
    // }

    // Data transfer object now
    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageModel model)
    {
        if (model.BusinessUserId == null || model.ResearchId == null)
        {
            return BadRequest("Both businessUserId and researchId must be provided.");
        }

        var messageDto = await _chatService.SendMessage(model.ChatId, model.SenderId, model.Content, model.BusinessUserId, model.ResearchId);
        return Ok(messageDto);
    }

    [HttpGet("getChats")]
    public async Task<IActionResult> GetChatsByResearchAndPanelMember(Guid researchId, Guid panelMemberId)
    {
        var chats = await _context.Chats
                            .Include(c => c.Messages)
                            .Where(c => c.ResearchId == researchId && c.PanelMemberId == panelMemberId)
                            .ToListAsync();

        return Ok(chats);
    }

    [HttpGet("getChatsByResearch")]
    public async Task<IActionResult> GetChatsByResearch(Guid researchId)
    {
        var chats = await _context.Chats
                            .Include(c => c.Messages)
                            .Where(c => c.ResearchId == researchId)
                            .Select(chat => new ChatDto
                            {
                                Id = chat.Id,
                                BusinessUserId = chat.BusinessUserId,
                                ResearchId = chat.ResearchId,
                                Messages = chat.Messages.Select(message => new ChatMessageDto
                                {
                                    Id = message.Id,
                                    Content = message.Content,
                                    Timestamp = message.Timestamp,
                                    SenderId = message.SenderId
                                }).ToList()
                            })
                            .ToListAsync();

        return Ok(chats);
    }
}
