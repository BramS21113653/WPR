public class ParentGuardian : ApplicationUser
{
    public string RelationToPanelMember { get; set; }

    // Navigation properties
    public virtual ICollection<PanelMember> PanelMembers { get; set; }
}
