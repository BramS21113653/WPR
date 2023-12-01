public class Message
{
    public string Id { get; set; }
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }

    public string BusinessUserId { get; set; }  // Foreign key property, if applicable
    public virtual BusinessUser BusinessUser { get; set; }  // Navigation property

    // Navigation properties
    public virtual ApplicationUser Sender { get; set; }
    public virtual ApplicationUser Receiver { get; set; }
}
