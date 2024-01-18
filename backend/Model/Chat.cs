public class Chat
{
    public Guid Id { get; set; }
    public Guid? PanelMemberId { get; set; } // Make PanelMemberId nullable
    public Guid BusinessUserId { get; set; }
    public Guid ResearchId { get; set; } 

    // Navigatie-eigenschappen
    public virtual PanelMember PanelMember { get; set; }
    public virtual BusinessUser BusinessUser { get; set; }
    public virtual Research Research { get; set; } 
    public virtual ICollection<ChatMessage> Messages { get; set; }
}
