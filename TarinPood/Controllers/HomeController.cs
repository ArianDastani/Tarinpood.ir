using Application.Services.Slider;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TarinPood.Models;

namespace TarinPood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISliderServices _sliderServices;

        public HomeController(ILogger<HomeController> logger, ISliderServices sliderServices)
        {
            _logger = logger;
            _sliderServices = sliderServices;
        }

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel
            {
                SliderIndex = _sliderServices.GetSliderIndex().Data,
            };
            return View(indexViewModel);
        }

        [Route("/about")]
        public IActionResult about()
        {
            return View();
        }

        [Route("/Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("/Error404")]
        public IActionResult Error404()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}