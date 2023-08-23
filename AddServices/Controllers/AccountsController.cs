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
using AddServices.DTO;
using AddServices.Models.FrontEndModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using AddServices.JwtFeatures;
using AddServices.Email_Sendgrid;



namespace AddServices.Controllers
{


    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {



        private IMailService _mailService;
        private readonly UserManager<ApplicationUser> _userManager;
        // private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;
        // public AccountsController(UserManager<ApplicationUser> userManager, IMapper mapper, JwtHandler jwtHandler)
       // public AccountsController(UserManager<ApplicationUser> userManager, JwtHandler jwtHandler)
              public AccountsController(IMailService mailService, UserManager<ApplicationUser> userManager, JwtHandler jwtHandler)
        {
            _mailService = mailService;
            _userManager = userManager;
            // _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Registration")]
        
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            // var user = _mapper.Map<User>(userForRegistration);
            ApplicationUser user = new ApplicationUser();
            //### user.id must be zero to add an id automatically. otherwise new user may not be created 
            user.UserName = userForRegistration.Email;
            user.Email = userForRegistration.Email;
            user.FirstName = userForRegistration.FirstName;
            user.LastName = userForRegistration.LastName;


            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            await _userManager.AddToRoleAsync(user, "Viewer");

            return StatusCode(201);
        }


       

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });


           // test email
                await _mailService.SendEmailAsync(userForAuthentication.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
              


            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = await _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
                return BadRequest("Invalid Request");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var param = new Dictionary<string, string>
    {
        {"token", token },
        {"email", forgotPasswordDto.Email }
    };
            var callback = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(forgotPasswordDto.ClientURI, param);
            
           // var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
           // await _emailSender.SendEmailAsync(message);

            await _mailService.SendEmailAsync(user.Email, "Reset password token", callback);



            return Ok();
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                return BadRequest("Invalid Request");
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
            if (!resetPassResult.Succeeded)
            {
                var errors = resetPassResult.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }
            return Ok();
        }

    }
}