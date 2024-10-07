using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TechStore.Config;

public static class JWT
{
    public static string GenerateJwtToken(IConfiguration _configuration)
    {
        // Create a security key using the secret key from configuration.
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_KEY"]));

        // Create signing credentials using the security key and HMAC-SHA256 algorithm.
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Define the claims to include in the token, such as the user's email and a unique identifier (JTI).
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Build the JWT token with the defined issuer, audience, claims, expiration time, and signing credentials.
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT_ISSUER"],
            audience: _configuration["JWT_AUDIENCE"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JWT_EXPIREMINUTES"])),
            signingCredentials: credentials                    // Signing credentials for token security
        );

        // Return the JWT token as a string.
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}