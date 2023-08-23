using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddServices.Models;
using AddServices.Models.FrontEndModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// ## keep for reference. the implementation was successful with jwt token method and postman

namespace AddServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AccountController(ILogger<AccountController> logger,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration config)
        {
            this.logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.config = config;
        }



        [HttpPost("register")]
        // [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await this.userManager.FindByEmailAsync(model.Email);
                if (existingUser == null)
                {
                    ApplicationUser user = new ApplicationUser();
                   //### user.id must be zero to add an id automatically. otherwise new user may not be created 
                    user.UserName = model.Email;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;

                    IdentityResult result = userManager.CreateAsync(user, model.Password).Result;

                    if (result.Succeeded)
                    { /*# exception thrown System.InvalidOperationException: Role USER does not exist.
   at Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore`9.AddToRoleAsync(TUser user, String normalizedRoleName, CancellationToken cancellationToken) */

                        // await userManager.AddToRoleAsync(user, "User");

                        return Created("", model);
                    }
                }

            }

            return BadRequest();
        }

        /*
         https://localhost:44343/api/Account/login
        {  
    "Email" : "lal2@gmail.com",
    "Password" : "Aspnetproj-73"
}
         */

        [HttpPost("login")]
        //  [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var passwordCheck = await this.signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (passwordCheck.Succeeded)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            this.config["Tokens:Issuer"],
                            this.config["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddHours(3),
                            signingCredentials: credentials
                            );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });
                    }

                }
                else
                {
                    return Unauthorized();
                }
            }

            return BadRequest();
        }


    }
}