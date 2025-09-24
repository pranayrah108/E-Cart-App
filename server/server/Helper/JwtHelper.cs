using Microsoft.IdentityModel.Tokens;
using server.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace server.Helper
{
    public class JwtHelper : IJwtHelper
    {
        private readonly IConfiguration _config;

        public JwtHelper(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwtToken(User user)
        {
            // ✅ Read the key from the correct section
            var secret = _config["JwtKey:Key"] ?? throw new Exception("Jwt key is missing");
            var issuer = _config["JwtKey:Issuer"];
            var audience = _config["JwtKey:Audience"];

            if (secret.Length < 64) // HS512 requires >= 512 bits (64 bytes)
                throw new Exception("Jwt key must be at least 64 characters for HS512");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("UserName", user.UserName)
            };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
