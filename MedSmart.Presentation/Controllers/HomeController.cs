using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Application.Services.MedSmart.Core.Domain.Application.Services;
using MedSmart.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedSmart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerrequest)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = registerrequest.username;
                user.Email = registerrequest.gmail;
                IdentityResult result = await userManager.CreateAsync(user, registerrequest.password);
                if (result.Succeeded)
                {
                    return Ok("Created");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("pass", item.Description);
                }

            }
            return BadRequest(ModelState);

        }
        [HttpPost("LOgin")]
        public async Task<IActionResult> Login(LoginDto loginrequest)
        {
           
            return BadRequest(ModelState);



        }
    }

    
}
