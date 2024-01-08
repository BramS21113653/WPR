public class Message
{
    public string Id { get; set; }  // Assuming Id is a string. If you want it to be Guid, change accordingly.
    public Guid SenderId { get; set; }  // Changed from string to Guid
    public Guid ReceiverId { get; set; }  // Changed from string to Guid
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }

    public Guid BusinessUserId { get; set; }  // Change to Guid if BusinessUser Id is of type Guid
    public virtual BusinessUser BusinessUser { get; set; }  // Navigation property

    // Navigation properties
    public virtual ApplicationUser Sender { get; set; }
    public virtual ApplicationUser Receiver { get; set; }
}
