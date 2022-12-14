using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Yumyum.Core.Exceptions;
using Yumyum.Data;
using Yumyum.Infrastructure.Logger;

namespace Yumyum.Infrastructure.Services.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerManager _loggerManager;
       // private readonly YumyumDbContext _context;


        public JwtTokenGenerator(IConfiguration configuration, ILoggerManager loggerManager/*, YumyumDbContext context*/)
        {
            _configuration = configuration;
            _loggerManager = loggerManager;
       //     _context = context;
        }

        public string Generate(ApplicationUser user)
        {
            //var emailOrPhoneIsExist = _context.Users.Any(x=> x.Email == user.Email || x.PhoneNumber == user.PhoneNumber);

            //if (emailOrPhoneIsExist)
            //{
            //    throw new DuplicateEmailOrPhoneException();
            //}
            // Claims
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.Email , user.Email),
            };

                //SecretKey
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secert"]));

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // token 
                var token = new JwtSecurityToken(
                   issuer: _configuration["JWT:ValidIssuer"],
                   audience: _configuration["JWT:ValidAudience"],
                   claims: claims,
                   expires: DateTime.Now.AddMinutes(10),
                   signingCredentials: cred);

                return new JwtSecurityTokenHandler().WriteToken(token);
           
            
        }
    }
}
