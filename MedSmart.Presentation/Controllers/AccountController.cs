
using MedSmart.Core.Domain.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedSmart.Presentation.Controllers
{
<<<<<<< HEAD:MedSmart.Presentation/Controllers/HomeController.cs
//    [Route("api/[controller]")]
//    [ApiController]
//    public class HomeController : ControllerBase
//    {
//        private readonly UserManager<AppUser> userManager;
=======
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
>>>>>>> master:MedSmart.Presentation/Controllers/AccountController.cs

//        public AccountController(UserManager<AppUser> userManager)
//        {
//            this.userManager = userManager;
//        }
//        [HttpPost("Register")]
//        public async Task<IActionResult> Register(RegisterDto registerrequest)
//        {
//            if (ModelState.IsValid)
//            {
//                AppUser user = new AppUser();
//                user.UserName = registerrequest.username;
//                user.Email = registerrequest.gmail;
//                IdentityResult result = await userManager.CreateAsync(user, registerrequest.password);
//                if (result.Succeeded)
//                {
//                    return Ok("Created");
//                }
//                foreach (var item in result.Errors)
//                {
//                    ModelState.AddModelError("pass", item.Description);
//                }

//            }
//            return BadRequest(ModelState);

//        }
//        [HttpPost("LOgin")]
//        public async Task<IActionResult> Login(LoginDto loginrequest)
//        {
           
//            return BadRequest(ModelState);



//        }
//    }

    
}
