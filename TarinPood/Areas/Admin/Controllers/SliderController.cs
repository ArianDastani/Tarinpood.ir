using Application.Services.Slider;
using Common.Alert;
using Microsoft.AspNetCore.Mvc;

namespace TarinPood.Areas.Admin.Controllers
{
    public class SliderController : AdminBaseController
    {
        private ISliderServices _sliderServices;
        public SliderController(ISliderServices sliderServices)
        {
            _sliderServices = sliderServices;
        }
        public IActionResult Index()
        {
            var res = _sliderServices.GetAllSliderForAdmin();

            return View(res.Data);
        }

        public IActionResult Add(string h2,string h5,int order,IFormFile image)
        {
            var res = _sliderServices.AddImageSlider(new AddImageSliderDto { SliderH2Content = h2, SliderH5Content = h5, SliderOrder = order }, image);

            if(res.IsSuccess)
            {
                notify("عملیات موفق", notifyType.success, res.Message);
            }
            else
            {
                notify("هشدار", notifyType.warning, res.Message);

            }

            return Redirect("/Admin/Slider");
        }

        public IActionResult Remove(int SliderId)
        {
            var res = _sliderServices.Remove(SliderId);

            return Json(res);
        }

        public IActionResult Edit(int SliderId, string SliderH2Content, string SliderH5Content, int SliderOrder)
        {
            var res = _sliderServices.Edit(SliderId, SliderH2Content, SliderH5Content, SliderOrder);
            return Json(res);
        }
    }
}
