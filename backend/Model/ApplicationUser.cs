using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

public class ApplicationUser : IdentityUser
{
    // Additional properties common to all users
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Navigation properties
    public virtual ICollection<Message> MessagesSent { get; set; }
    public virtual ICollection<Message> MessagesReceived { get; set; }
}
