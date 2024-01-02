using Application.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TarinPood.Controllers
{
    public class AuthenticationController : Controller
    {
        private IUserServices _userServices;
        public AuthenticationController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string UserId, string Pass)
        {
            var res = _userServices.UserLogin(UserId, Pass);

            if (res.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,res.Data.UId.ToString()),
                    new Claim("UserId",res.Data.UId.ToString()),


                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var pricipal = new ClaimsPrincipal(identity);
                var propertis = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };

                HttpContext.SignInAsync(pricipal, propertis);
            }

            return Json(res);
        }


        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");

        }
    }
}
