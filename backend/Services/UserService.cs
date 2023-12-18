using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AppSettings _appSettings; // AppSettings should contain your JWT secret

    public UserService(UserManager<ApplicationUser> userManager, IOptions<AppSettings> appSettings)
    {
        _userManager = userManager;
        _appSettings = appSettings.Value;
    }

    public async Task<IdentityResult> Register(RegisterRequest model)
    {
        var user = new ApplicationUser
        {
            // Set user properties from the model
        };

        return await _userManager.CreateAsync(user, model.Password);
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        var user = await _userManager.FindByNameAsync(model.Username) ?? await _userManager.FindByEmailAsync(model.Username);
        if (user != null) {
            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid) 
            {
                return null;
            }

            // Authentication successful, generate jwt token
            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }
        return null;
    }

    private string GenerateJwtToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] 
            { 
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
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
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model); // Matching return type
}
