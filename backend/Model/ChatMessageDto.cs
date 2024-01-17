public class ChatMessageDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
    public Guid SenderId { get; set; }
    // Add other fields as needed, but avoid navigation properties that lead to circular references
}
