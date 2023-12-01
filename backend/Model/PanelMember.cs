public class PanelMember : ApplicationUser
{
    public string PostCode { get; set; }
    public string DisabilityType { get; set; }
    public string UsedAssistiveTools { get; set; }
    public string ConditionDisease { get; set; }
    public string PreferredResearchTypes { get; set; } // JSON string or separate table
    public string PreferredApproach { get; set; }
    public bool ConsentForCommercialApproach { get; set; }
    public string AvailabilityTimes { get; set; } // JSON string or separate table

    // Foreign key for ParentGuardian
    public string ParentGuardianId { get; set; } 
    public ParentGuardian ParentGuardian { get; set; }

    // Navigation properties
    public virtual ICollection<Participation> Participations { get; set; }
}
