using AutoMapper;
using BookStore.API.DTOs;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yumyum.Core.DTOs;
using Yumyum.Core.ViewModels;
using Yumyum.Infrastructure.Logger;
using Yumyum.Infrastructure.Services.Auth;

namespace Yumyum.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtToken;
        private readonly ILoggerManager _loggerManager;


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;


        public AuthenticationController(IJwtTokenGenerator jwtToken, UserManager<ApplicationUser> userManager,
             ILoggerManager loggerManager,
            IMapper mapper)
        { 
            _jwtToken = jwtToken;
            _userManager = userManager;
            _mapper = mapper;
            _loggerManager = loggerManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestDto login)
        {
            var user = await _userManager.FindByNameAsync(login.username);
            var token = "";
            if (user != null && await _userManager.CheckPasswordAsync(user, login.password))
            {
                token = _jwtToken.Generate(user);
            }
            else
                throw new UnauthorizedAccessException();

            return Ok(new { token = token });
        }
        // imporntent i have proplem in this query i will soive it another time
        
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequestDto registerRequestDto)
        {
          
            var userExists = await _userManager.FindByNameAsync(registerRequestDto.Email);
            if (userExists != null)
            {
                return BadRequest("User exists!");
            }
            var identityUser = _mapper.Map<ApplicationUser>(registerRequestDto);
            identityUser.SecurityStamp = Guid.NewGuid().ToString();
            identityUser.UserName = registerRequestDto.Email;
            var result = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest("Error");
            }

            var token = _jwtToken.Generate(identityUser);

            return Ok(new RegisterResponseViewModel { Email = identityUser.Email, token = token, Username = identityUser.UserName });
        }
            

    }
}
