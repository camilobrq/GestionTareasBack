using BussinesLayer.AuthLogic.Abstracts;
using CommonsLayer.Configuration;
using CommonsLayer.DTO.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.AuthLogic.Implements
{
    public class JwtTokenProvider : IJwtTokenProvider
    {
        private readonly JwtTokenProviderOptions jwtOptions;

        public JwtTokenProvider(IOptions<JwtTokenProviderOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions.Value;
        }

        public string GetJwtToken(UserData user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtOptions.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Username),
                }),
                Expires = DateTime.UtcNow.Add(jwtOptions.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            if (user.Role != null)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, user.Role));
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);


            return tokenString;

        }
    }
}
