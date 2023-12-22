using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AppSettings _appSettings;

    public UserService(UserManager<ApplicationUser> userManager, IOptions<AppSettings> appSettings)
    {
        _userManager = userManager;
        _appSettings = appSettings.Value;
    }

    public async Task<IdentityResult> Register(RegisterRequest model)
    {
        // Ensure required fields are not null or empty
        if (string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.LastName))
        {
            return IdentityResult.Failed(new IdentityError { Description = "FirstName and LastName are required." });
        }

        var user = new ApplicationUser
        {
            UserName = model.Username,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            // Other properties...
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        // Handle the result...
        return result;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        var user = await _userManager.FindByNameAsync(model.Username) ?? await _userManager.FindByEmailAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            // Authentication successful, generate jwt token
            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }
        // Authentication failed
        return null;
    }

    private string GenerateJwtToken(ApplicationUser user)
    {
        if (string.IsNullOrWhiteSpace(_appSettings.SecretKey)) // Use SecretKey here
        {
            throw new InvalidOperationException("JWT Secret key is not configured properly.");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey); // Use SecretKey here
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // Add more claims as needed
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
public interface IUserService
{
    Task<IdentityResult> Register(RegisterRequest model);
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
}