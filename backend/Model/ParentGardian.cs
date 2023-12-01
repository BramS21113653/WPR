public class ParentGuardian : ApplicationUser
{
    public string RelationToPanelMember { get; set; }

    // Collection to hold the dependent panel members
    public virtual ICollection<PanelMember> PanelMembers { get; set; }

    public ParentGuardian()
    {
        PanelMembers = new HashSet<PanelMember>();
    }
}
