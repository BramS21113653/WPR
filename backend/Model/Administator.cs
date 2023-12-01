public class Administrator : ApplicationUser
{
    // Additional admin-specific properties (if any)
    public virtual ICollection<PanelMember> SupervisedPanelMembers { get; set; }

    // Constructor to initialize the collection
    public Administrator()
    {
        SupervisedPanelMembers = new HashSet<PanelMember>();
    }
}
