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
    // public string ParentGuardianId { get; set; } 
    // public ParentGuardian ParentGuardian { get; set; }

    public Guid? ParentGuardianId { get; set; }  // Changed from string to Guid
    public virtual ParentGuardian ParentGuardian { get; set; }

    // todo: wijs een administrator toe bij het aanmaken van een panelmember en haal de nullable weg hier!!!
    public Guid? AdministratorId { get; set; } // Nullable for now 

    // Navigation properties
    public virtual ICollection<Participation> Participations { get; set; }

    public virtual Administrator Administrator { get; set; }

    public ICollection<ResearchInterest> ResearchInterests { get; set; }
}
