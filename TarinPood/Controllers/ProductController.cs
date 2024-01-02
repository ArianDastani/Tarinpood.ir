using Application.Services.Product.Querise.IGetProductForIndexService;
using Microsoft.AspNetCore.Mvc;

namespace TarinPood.Controllers
{
    public class ProductController : Controller
    {
        private IGetProductForIndexService _getProductForIndex;
        public ProductController(IGetProductForIndexService getProductForIndex)
        {
            _getProductForIndex = getProductForIndex;
        }
        public IActionResult Index()
        {
            var res = _getProductForIndex.Execute();
            return View(res.Data);
        }

        public IActionResult Detail(int id)
        {
            var res=_getProductForIndex.GetDetailProduct(id);

            if (res.IsSuccess != true)
            {
                return Redirect("/");
            }

            return View(res.Data);
        }
    }
}
