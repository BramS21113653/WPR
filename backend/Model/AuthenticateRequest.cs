using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AuthenticateRequest
{
    public string Username { get; set; }
    public string Password { get; set; }

    // You can also include fields like 'RememberMe' if needed
}
