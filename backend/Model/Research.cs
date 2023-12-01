public class Research
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ConductorId { get; set; } // FK to BusinessUser or Administrator
    public DateTime DateTime { get; set; }
    public string LocationOnline { get; set; }
    public string Reward { get; set; }
    public string ResearchType { get; set; }
    public string Status { get; set; }

    // Navigation properties
    public virtual BusinessUser Conductor { get; set; }
    public virtual ICollection<Participation> Participations { get; set; }
}
