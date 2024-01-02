using Application.InterFace;
using Common.DTO;
using Common.SaveFile;
using Microsoft.AspNetCore.Http;
using Persistance.Context;

namespace Application.Services.Slider;

public class SliderServices : ISliderServices
{
    private IDatabaseContext _databaseContext;
    public SliderServices(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public ResultDto AddImageSlider(AddImageSliderDto ImageSliderDto, IFormFile Image)
    {
        var count = _databaseContext.MainSliders.Count();
        if (count < 3) 
        {
            if (ImageSliderDto.SliderOrder == null || ImageSliderDto.SliderOrder == 0 ||
                string.IsNullOrWhiteSpace(ImageSliderDto.SliderH2Content) || string.IsNullOrWhiteSpace(ImageSliderDto.SliderH5Content))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "موارد خواسته را وارد کنید"
                };
            }

            if (Image == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "موارد خواسته را وارد کنید"
                };
            }

            string imageName = "";

            if (Image != null)
            {
                imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(Image.FileName);
                UploadFileExtension.AddImageAjaxToServer(Image, imageName, $"{Directory.GetCurrentDirectory()}/wwwroot/content/ImageSlider/");
            }

            MainSlider mainSlider = new MainSlider()
            {
                SliderH2Content = ImageSliderDto.SliderH2Content,
                SliderH5Content = ImageSliderDto.SliderH5Content,
                SliderOrder = ImageSliderDto.SliderOrder,
                SliderPicture = imageName,
            };

            _databaseContext.MainSliders.Add(mainSlider);
            _databaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "با موفقیت انجام شد"
            };
        }
        else
        {
            return new ResultDto
            {
                IsSuccess=false,
                Message="امکان اضافه کردن اسلایدر بیشتر از ۳ عدد وجود ندارد"
            };
        }

            
    }

    public ResultDto Edit(int Id, string H1, string H5, int Order)
    {
        if (Id == 0 || Id == null || string.IsNullOrWhiteSpace(H1) || string.IsNullOrWhiteSpace(H5) || Order == 0 || Order == null)
        {
            return new ResultDto
            {
                Message = "خطا در انجام عملیات",
                IsSuccess = false,
            };
        }

        var slider = _databaseContext.MainSliders.FirstOrDefault(x => x.SliderId == Id);

        if (slider == null)
        {
            return new ResultDto
            {
                Message = "یافت نشد",
                IsSuccess = false,
            };
        }

        slider.SliderOrder = Order;
        slider.SliderH5Content= H5;
        slider.SliderH2Content= H1;
        _databaseContext.SaveChanges();

        return new ResultDto
        {
            IsSuccess= true,
            Message="با موفقیت ویرایش شد"
        };
    }

    public ResultDto<List<GetAllSliderAdminDto>> GetAllSliderForAdmin()
    {
        return new ResultDto<List<GetAllSliderAdminDto>>
        {
            Data = _databaseContext.MainSliders.OrderBy(x => x.SliderOrder)
                .Select(x => new GetAllSliderAdminDto
                {
                    SliderH2Content=x.SliderH2Content,
                    SliderH5Content=x.SliderH5Content,
                    SliderId=x.SliderId,
                    SliderOrder=x.SliderOrder,
                    SliderPicture=x.SliderPicture,

                }).ToList(),IsSuccess=true,
            Message=""
        };

    }

    public ResultDto<List<GetSliderIndexDto>> GetSliderIndex()
    {
        return new ResultDto<List<GetSliderIndexDto>>
        {
            Data = _databaseContext.MainSliders.OrderBy(x => x.SliderOrder)
                .Select(x => new GetSliderIndexDto
                {
                    SliderH2Content = x.SliderH2Content,
                    SliderH5Content = x.SliderH5Content,
                    SliderPicture = x.SliderPicture,
                }).ToList(), IsSuccess = true,
            Message = ""
        };

    }

    public ResultDto Remove(int Id)
    {
        if (Id == 0 || Id == null)
        {
            return new ResultDto
            {
                Message = "یافت نشد",
                IsSuccess = false,
            };
        }

        var slider=_databaseContext.MainSliders.FirstOrDefault(x=>x.SliderId==Id);

        if (slider == null)
        {
            return new ResultDto
            {
                Message = "یافت نشد",
                IsSuccess = false,
            };
        }
        _databaseContext.MainSliders.Remove(slider);
        _databaseContext.SaveChanges();

        return new ResultDto
        {
            IsSuccess=true,
            Message="با موفقیت حذف شد"
        };
    }
}