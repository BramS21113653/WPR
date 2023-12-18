using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class RegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // Add other registration fields as needed
}
