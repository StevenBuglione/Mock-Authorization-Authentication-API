using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Dtos.AppUserDtos;
using API.Dtos.AuthDtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController: ControllerBase
    {
        private readonly IConfiguration _config;
        private IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(IConfiguration config, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _config = config;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Post Request to Register a new AppUser
        [HttpPost("register")]
        public async Task<IActionResult> Register(AppUserForRegisterDto appUserForRegisterDto)
        {
            var userToCreate = _mapper.Map<AppUser>(appUserForRegisterDto);

            var result = await _userManager.CreateAsync(userToCreate, appUserForRegisterDto.Password);

            var userToReturn = _mapper.Map<AppUserForDetailedDto>(userToCreate);

            if (result.Succeeded)
            {
                return CreatedAtRoute("GetAppUser", new { controller = "AppUsers", id = userToCreate.Id }, userToReturn);
            }

            return BadRequest(result.Errors);
        }


        //Post Request to Login a AppUser
        [HttpPost("login")]
        public async Task<IActionResult> Login(AppUserForLoginDto appUserForLoginDto)
        {
            var user = await _userManager.FindByNameAsync(appUserForLoginDto.Username);

            var result = await _signInManager.CheckPasswordSignInAsync(user, appUserForLoginDto.Password, false);

            if (result.Succeeded)
            {
                var appUser = _mapper.Map<AppUserForListDto>(user);

                return Ok(new
                {
                    token = GenerateJwtToken(user).Result,
                    user = appUser
                });

            }

            return Unauthorized();
        }


        //Method to Generate JWT Token
        private async Task<string> GenerateJwtToken(AppUser appUser)
        {
            var claims = new List<Claim>
           {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
                new Claim(ClaimTypes.Name, appUser.UserName)
            };

            var roles = await _userManager.GetRolesAsync(appUser);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
