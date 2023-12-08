using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<string> Register(RegisterDto registerDto)
    {
        // Implement logic to register a new user
        var user = new ApplicationUser { UserName = registerDto.Username };
        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (result.Succeeded)
        {
            // You can customize the claims or roles assigned to the user upon registration
            await _userManager.AddClaimAsync(user, new Claim("CustomClaim", "RegisteredUser"));

            return GenerateJwtToken(user);
        }

        return null;
    }

    public async Task<string> Login(LoginDto loginDto)
    {
        // Implement logic to authenticate and log in a user
        var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            return GenerateJwtToken(user);
        }

        return null;
    }

    private string GenerateJwtToken(ApplicationUser user)
    {
        // Implement logic to generate a JWT token for the authenticated user
        // Use a JWT library or build the token manually with the required claims
        // Here, we are using the Microsoft.IdentityModel.Tokens library for
        // simplicity

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                // Add additional claims as needed
            }),
            Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}