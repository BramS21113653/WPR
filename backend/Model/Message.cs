public class Message
{
    public string Id { get; set; }
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }

    // Navigation properties
    public virtual ApplicationUser Sender { get; set; }
    public virtual ApplicationUser Receiver { get; set; }
}
