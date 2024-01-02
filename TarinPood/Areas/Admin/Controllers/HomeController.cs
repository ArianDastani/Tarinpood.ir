using Microsoft.AspNetCore.Mvc;

namespace TarinPood.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
