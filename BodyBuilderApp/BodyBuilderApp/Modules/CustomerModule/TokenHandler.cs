using BodyBuilderApp.Models;
using BodyBuilderApp.Modules.CustomerModule.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BodyBuilderApp.Modules.CustomerModule
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;
        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> CreateTokenAsync(Customer customer)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, customer.Name));
            claims.Add(new Claim(ClaimTypes.Email, customer.Email));
            claims.Add(new Claim(ClaimTypes.Role, customer.Role));
        

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(35),
                signingCredentials: credentials);
            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
