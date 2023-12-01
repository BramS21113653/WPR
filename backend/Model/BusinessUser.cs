public class BusinessUser : ApplicationUser
{
    public string CompanyName { get; set; }
    public string Location { get; set; }
    public string WebsiteURL { get; set; }
    public string ContactInfo { get; set; }

    // Navigation properties
    public virtual ICollection<Research> Researches { get; set; }
}
