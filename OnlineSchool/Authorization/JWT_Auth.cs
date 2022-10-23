using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Authorization
{
    public class JWT_Auth 
    {
        public String GenerateToken(String Auth_ID , String email,String companyname)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY_Details.key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(
                signingCredentials: credentials,
                issuer: KEY_Details.Issuer,
                audience: KEY_Details.Audiunce,
                claims: new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, Auth_ID),
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Role,companyname),
                },
                expires: DateTime.UtcNow.AddMonths(2));

            var handler = new JwtSecurityTokenHandler();
            ////Console.WriteLine(handler.WriteToken(secToken));
            return handler.WriteToken(secToken);
        }

        public  bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            try
            {
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = KEY_Details.Issuer,
                ValidAudience = KEY_Details.Audiunce,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY_Details.key)) // The same key as the one that generate the token
            };
        }

     
    }
}
