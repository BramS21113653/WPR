public class ChatService
{
    private readonly AppContext _context;

    public ChatService(AppContext context)
    {
        _context = context;
    }

    public async Task<Chat> CreateChat(Guid panelMemberId, Guid businessUserId, Guid researchId)
    {
        var chat = new Chat
        {
            PanelMemberId = panelMemberId,
            BusinessUserId = businessUserId,
            ResearchId = researchId
        };

        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();

        return chat;
    }

    public async Task<ChatMessage> SendMessage(Guid chatId, Guid senderId, string content)
    {
        var message = new ChatMessage
        {
            ChatId = chatId,
            SenderId = senderId,
            Content = content,
            Timestamp = DateTime.UtcNow
        };

        _context.ChatMessages.Add(message);
        await _context.SaveChangesAsync();

        return message;
    }
}
