using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly ChatService _chatService;

    public ChatController(ChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateChat([FromBody] ChatCreateModel model)
    {
        var chat = await _chatService.CreateChat(model.PanelMemberId, model.BusinessUserId, model.ResearchId);
        return Ok(chat);
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageModel model)
    {
        var message = await _chatService.SendMessage(model.ChatId, model.SenderId, model.Content);
        return Ok(message);
    }
}
