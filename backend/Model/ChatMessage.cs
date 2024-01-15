public class ChatMessage
{
    public Guid Id { get; set; }
    public Guid ChatId { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
    public Guid SenderId { get; set; }

    public virtual Chat Chat { get; set; }
    public virtual ApplicationUser Sender { get; set; }
}
