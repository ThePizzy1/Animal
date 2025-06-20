﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ANIMAL.DAL.DataModel;
using ANIMAL.Model;
using Microsoft.AspNetCore.Authorization;
using ANIMAL.Repository.Automaper;
using Microsoft.EntityFrameworkCore;
using NLog;
using Microsoft.Extensions.Logging;

namespace ANIMAL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly SignInManager<ApplicationUser> _signInManager; 
        private readonly IConfiguration _configuration;
        private readonly AnimalRescueDbContext _context;
        private IRepositoryMappingService _mappingService;
        public AuthController(ILogger<AuthController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IRepositoryMappingService mapper)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mappingService = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RgisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new ApplicationUser { UserName = model.Username};
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return Ok(new { message = "User registered successfully" });
            }
            else
            {
              _logger.LogWarning("Error registering User");
                return BadRequest(result.Errors);
            }
        }
        [HttpPost("registerAdmin")]
        public async Task<IActionResult> RegisterWorker([FromBody] RgisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new ApplicationUser { UserName = model.Username, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNumber };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
                _logger.LogInformation("User registered successfully ");
                return Ok(new { message = "User registered successfully" });
            }
            else
            {
                _logger.LogWarning("Error registering User");
            }
            
            return BadRequest(result.Errors);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userManager.Users.ToListAsync();
            var userList= new List<object>();

            foreach(var u in user)
            {
                var role = await _userManager.GetRolesAsync(u);
                userList.Add(new 
                {u.FirstName,
                 u.LastName,
                 u.UserName,
                 u.Email,
                 u.PhoneNumber,
                Roles = role              
                });
            }

            if (userList == null)
            {
                _logger.LogError("Korisnik nije pronađen.");
                return NotFound($"Korisnik nije pronađen.");
            }
            else
            {
                _logger.LogInformation("Korisnik je pronađen.");
            }
            return Ok(userList);
        }
        [HttpGet("getUserByUsername/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                _logger.LogWarning("Korisnik nije pronađen.");
                return NotFound($"Korisnik s korisničkim imenom '{username}' nije pronađen.");
            }
            var userDto = new
            {
                Id = user.Id,
                Username = user.UserName,                         
            };
            if (user != null)
            {
                _logger.LogInformation("Korisnik je pronađen.");
            }
            return Ok(userDto);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var token = GenerateJwtToken(user);
                _logger.LogInformation("Korisnik je logiran. Ovo je log iz auth");
                return Ok(new { token });
            }
            else
            {
                _logger.LogError("Korisnik nije logiran. Ovo je log iz auth");
            }
            return Unauthorized();
        }
        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>{
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id_usera", user.Id)
                    };

           
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
