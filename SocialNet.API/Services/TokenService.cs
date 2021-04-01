using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialNet.API.Interfaces;
using SocialNet.API.Models;

namespace SocialNet.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(User usr)
        {
            //Step 1 : Create claims => values that are to be stored (payload)
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId,usr.UserName)
            };

            //Step 2 : Create Signing Credentials and Securit Algorithm - which will be used to check authencity of the token
            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);

            //Step 3 : Start building the token - add description/structure
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = creds
            };

            //Step 4 : Create the token using tokenhandler and tokendescriptor
            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(tokenDescriptor);

            //Step 5 : Serialize and return
            return tokenhandler.WriteToken(token);

        }
    }
}