using Application.Services.Product.Command.AddAttripute;
using Application.Services.Product.Command.AddProduct;
using Application.Services.Product.Command.RemoveProduct;
using Application.Services.Product.Querise.IGetAllProductForAdminService;
using Application.Services.Product.Querise.IGetAttriputeForAdminService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TarinPood.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private IAddAttriputeService _addAttriputeService;
        private IGetAttriputeForAdminService _getAttriputeForAdminService;
        private IAddProductService _addProductService;
        private IGetAllProductForAdminService _getAllProductForAdminService;
        private IRemoveProductService _removeProductService;
        public ProductController(IAddAttriputeService addAttriputeService, IGetAttriputeForAdminService getAttriputeForAdminService, IAddProductService addProductService, IGetAllProductForAdminService getAllProductForAdminService,IRemoveProductService removeProductService)
        {
            _addAttriputeService = addAttriputeService;
            _getAttriputeForAdminService = getAttriputeForAdminService;
            _addProductService = addProductService;
            _getAllProductForAdminService = getAllProductForAdminService;
            _removeProductService = removeProductService;
        }
        public IActionResult Index()
        {

            var res = _getAllProductForAdminService.Execute();
            return View(res.Data);
        }

        [HttpGet]
        public IActionResult AddNewProduct(int id)
        {

            var res = _addProductService.FillProduct(id);

            ViewBag.Attribute = new SelectList(_getAttriputeForAdminService.Execute().Data, "Name", "Name");
            return View(res.Data);
        }

        [HttpPost]
        public IActionResult AddNewProduct(List<ProductFeatures> Features,int Id, string Name, string Description)
        {
            var imageproduct = Request.Form.Files.FirstOrDefault();

            var res = _addProductService.Execute(new AddProductDto
            {
                Description = Description,
                Name = Name,
                ProductId = Id,
            }, imageproduct, Features);

            return Json(res);
        }

        [HttpPost]
        public ActionResult AddAttripute(string AttriputeName)
        {
            var res = _addAttriputeService.Execute(new RequestAddAttributeDto { AttributeName = AttriputeName });
            notify("عملیات موفق", notifyType.success, res.Message);
            return Redirect("/admin");
        }

        public ActionResult removeProduct(int ProductId)
        {
            var res = _removeProductService.Execute(ProductId);

            return Json(res);
        }

        public IActionResult ChangeIsActiveProduct(int ProductId)
        {
            var res = _getAllProductForAdminService.ChangeIsActiveProduct(ProductId);

            return Json(res);
        }

        public IActionResult Attributes()
        {
            var res = _addAttriputeService.GetAllAttributeDto();

            return View(res.Data);
        }

        public IActionResult RemoveProductAttributes(int Id)
        {
            var res= _addAttriputeService.Remove(Id);
            return Json(res);
        }

        public IActionResult RemoveProductAttributes2(int Id)
        {
            var res = _addAttriputeService.RemoveAtt(Id);
            return Json(res);
        }

        public IActionResult ProductAttributes(int ProductId)
        {
            ViewBag.Attribute = new SelectList(_getAttriputeForAdminService.Execute().Data, "Name", "Name");
            ViewBag.ProductId = ProductId;

            var res = _addAttriputeService.GetAllAttributeProductDto(ProductId);

            return View(res.Data);
        }

        public IActionResult AddProductAttributes(int id, string AttributeName,string name)
        {
            var res = _addAttriputeService.AddProductAttribute(id, AttributeName, name);

            return Json(res);
        }

        public IActionResult EditProductAttributes(int ProductAttributeId,string ProductAttributeContent)
        {
            var res=_addAttriputeService.EditAttributeProduct(ProductAttributeId,ProductAttributeContent);

            return Json(res);
        }
    }
}
