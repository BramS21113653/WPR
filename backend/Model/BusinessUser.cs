public class BusinessUser : ApplicationUser
{
    public string CompanyName { get; set; }
    public string Location { get; set; }
    public string WebsiteURL { get; set; }
    public string ContactInfo { get; set; }

    // Navigation properties
    public virtual ICollection<Research> Researches { get; set; }
    public virtual ICollection<Message> CreatedMessages { get; set; }

    // Constructor to initialize the collection
    public BusinessUser()
    {
        Researches = new HashSet<Research>();
        CreatedMessages = new HashSet<Message>();
    }
}
