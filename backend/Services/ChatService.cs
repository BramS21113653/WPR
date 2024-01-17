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
public async Task<ChatMessageDto> SendMessage(Guid chatId, Guid senderId, string content, Guid? businessUserId, Guid? researchId)
{
    // Check if the chat exists
    var chat = await _context.Chats.FindAsync(chatId);

    // If the chat doesn't exist, create a new one
    if (chat == null)
    {
        // Ensure businessUserId and researchId have values before creating a new chat
        if (!businessUserId.HasValue || !researchId.HasValue)
        {
            throw new InvalidOperationException("Both businessUserId and researchId must be provided to create a new chat.");
        }
        chat = await CreateChat(senderId, businessUserId.Value, researchId.Value);
    }

        var message = new ChatMessage
        {
            ChatId = chat.Id,
            SenderId = senderId,
            Content = content,
            Timestamp = DateTime.UtcNow
        };

        _context.ChatMessages.Add(message);
        await _context.SaveChangesAsync();

        return new ChatMessageDto
        {
            Id = message.Id,
            Content = message.Content,
            Timestamp = message.Timestamp,
            SenderId = message.SenderId
        };
    }
}
