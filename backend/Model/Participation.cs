public class Participation
{
    public string Id { get; set; }
    public string PanelMemberId { get; set; }
    public string ResearchId { get; set; }
    public string Status { get; set; }

    // Navigation properties
    public virtual PanelMember PanelMember { get; set; }
    public virtual Research Research { get; set; }
}
