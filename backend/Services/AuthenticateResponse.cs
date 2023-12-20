public class AuthenticateResponse
{
    public ApplicationUser User { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(ApplicationUser user, string token)
    {
        User = user;
        Token = token;
    }

    // Other properties or methods...
}