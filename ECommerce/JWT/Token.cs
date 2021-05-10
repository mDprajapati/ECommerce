using ECommerce.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace ECommerce.JWT
{
    public class Token
    {
        public string GenerateToken(Users users )
        {
            string key = "my_secret_key_12345";
            var issuer = "https://localhost:44392";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim(JwtRegisteredClaimNames.NameId, users.ID.ToString()));
            permClaims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, users.UserName));
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Email, users.Password));

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(issuer, issuer, permClaims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}