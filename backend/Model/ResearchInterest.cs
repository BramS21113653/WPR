public class ResearchInterest
{
   public Guid PanelMemberId { get; set; }
   public string ResearchId { get; set; }

   public virtual PanelMember PanelMember { get; set; }
   public virtual Research Research { get; set; }
}
