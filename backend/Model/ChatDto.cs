public class ChatDto
{
    public Guid Id { get; set; }
    public Guid BusinessUserId { get; set; }
    public Guid ResearchId { get; set; }
    public List<ChatMessageDto> Messages { get; set; }
}