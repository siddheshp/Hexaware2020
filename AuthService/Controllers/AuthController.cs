using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([FromForm] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //check if role exists
                var roleName = roleManager.Roles
                    .FirstOrDefault(r => r.Id == registerDto.Role).NormalizedName;
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (roleExists)
                {
                    var user = new IdentityUser
                    {
                        UserName = registerDto.UserName,
                        Email = registerDto.Email,
                        NormalizedEmail = registerDto.Email
                    };
                    var result = await userManager.CreateAsync(user, registerDto.Password);
                    if (result.Succeeded)
                    {
                        var resultRole = await userManager.AddToRoleAsync(user, roleName);
                        if (resultRole.Succeeded)
                        {
                            return Created("register", "user registered successfully");
                        }
                        return BadRequest(resultRole.Errors);
                    }
                    return BadRequest(result.Errors);
                }
                else
                {
                    return BadRequest("Role does not exist");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
