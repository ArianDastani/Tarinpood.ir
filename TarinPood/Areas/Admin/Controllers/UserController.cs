using Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace TarinPood.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public IActionResult Index()
        {
            var res = _userServices.GetAllUser();
            return View(res.Data);
        }

        public IActionResult Add(string name, string Password)
        {
            var res = _userServices.Add(name, Password);
            return Redirect("/Admin/User");
        }

        public IActionResult Edit(int UId,string UName, string UPassword)
        {
            var res = _userServices.EditUser(UId, UName.Trim().ToLower(), UPassword);
            return Json(res);
        }

        public IActionResult Remove(int UId)
        {
            var res = _userServices.Remove(UId);

            return Json(res);
        }
    }
}
