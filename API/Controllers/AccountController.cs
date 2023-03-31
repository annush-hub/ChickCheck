using API.Dtos;
using API.Services;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, TokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserAuthDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var token = _tokenService.CreateToken(user, userRoles);

                return new UserAuthDto
                {
                    DisplayName = user.DisplayName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Username = user.UserName,
                    Expiration = token.ValidTo
                };
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserAuthDto>> Register([FromBody] RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
            {
                ModelState.AddModelError("username", "Username is already taken!");
                return ValidationProblem();
            }

            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                ModelState.AddModelError("email", "Email is already taken!");
                return ValidationProblem();
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Username
            };

            if (await _roleManager.RoleExistsAsync(UserRole.User.ToString()))
            {
                await _userManager.AddToRoleAsync(user, UserRole.User.ToString());
            }

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var token = _tokenService.CreateToken(user, userRoles);

                return new UserAuthDto
                {
                    DisplayName = user.DisplayName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Username = user.UserName,
                    Expiration = token.ValidTo
                };
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("registerAdmin")]
        public async Task<ActionResult<UserAuthDto>> RegisterAdmin([FromBody] RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
            {
                ModelState.AddModelError("username", "Username is already taken!");
                return ValidationProblem();
            }

            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                ModelState.AddModelError("email", "Email is already taken!");
                return ValidationProblem();
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Username
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!await _roleManager.RoleExistsAsync(UserRole.Admin.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin.ToString()));
            }

            if (!await _roleManager.RoleExistsAsync(UserRole.User.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRole.User.ToString()));
            }

            if (await _roleManager.RoleExistsAsync(UserRole.Admin.ToString()))
            {
                await _userManager.AddToRoleAsync(user, UserRole.Admin.ToString());
            }

            if (result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var token = _tokenService.CreateToken(user, userRoles);

                return new UserAuthDto
                {
                    DisplayName = user.DisplayName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Username = user.UserName,
                    Expiration = token.ValidTo
                };
            }

            return BadRequest(result.Errors);
        }
    }
}
