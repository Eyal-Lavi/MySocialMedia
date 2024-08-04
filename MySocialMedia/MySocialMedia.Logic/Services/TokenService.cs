using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Logic.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenService(string secret, string issuer, string audience)
        {
            _secret = secret;
            _issuer = issuer;
            _audience = audience;
        }
        public string GenerateToken(string userName)
        {

            //מידע ומזהה יחודי לטוקן
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim("username", userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            
            //יצירת מפתח אבטחה סימטרי על בסיס (_secret). מפתח זה ישמש לחתימה על הטוקן
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));

            //יצירת האישורים לחתימה (signing credentials) על ידי שימוש במפתח הסימטרי ובאלגוריתם HMAC SHA256.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    _issuer,
                    _audience,
                    claims,// מידע ומזהה יחודי לטוקן
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds //האישורים לחתימה
                    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
