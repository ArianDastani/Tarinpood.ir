using Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Application.Services.Slider
{
    public interface ISliderServices
    {
        ResultDto AddImageSlider(AddImageSliderDto ImageSliderDto, IFormFile Image);
        ResultDto<List<GetAllSliderAdminDto>> GetAllSliderForAdmin();
        ResultDto Remove(int Id);
        ResultDto Edit(int Id, string H1, string H5, int Order);

        ResultDto<List<GetSliderIndexDto>> GetSliderIndex();
    }
}
