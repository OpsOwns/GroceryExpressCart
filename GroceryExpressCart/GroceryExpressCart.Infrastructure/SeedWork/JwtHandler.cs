using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Infrastructure.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GroceryExpressCart.Infrastructure.SeedWork
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly JwtSettings _jwtSettings;
        public JwtGenerator(JwtSettings jwtSettings) => _jwtSettings = jwtSettings;
        public JwtDTO Generate(MemberShip memberShip)
        {
            var dateNow = DateTime.UtcNow;
            var claims = new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, memberShip.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, memberShip.Login.LoginValue),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, dateNow.ToTimeStamp().ToString(), ClaimValueTypes.Integer64)
            };
            var expires = dateNow.AddMinutes(_jwtSettings.ExpireMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                notBefore: dateNow,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JwtDTO
            {
                Token = token,
                Expires = expires.ToTimeStamp()
            };
        }

    }
}
