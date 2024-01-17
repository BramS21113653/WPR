public class SendMessageModel
{
   public Guid ChatId { get; set; }
   public Guid SenderId { get; set; }
   public string Content { get; set; }
   public Guid? BusinessUserId { get; set; }
   public Guid? ResearchId { get; set; }
}
