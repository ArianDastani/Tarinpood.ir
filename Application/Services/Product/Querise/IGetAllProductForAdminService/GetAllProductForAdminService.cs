using Application.InterFace;
using Common.DTO;

namespace Application.Services.Product.Querise.IGetAllProductForAdminService;

public class GetAllProductForAdminService : IGetAllProductForAdminService
{
    private IDatabaseContext _context;
    public GetAllProductForAdminService(IDatabaseContext context)
    {
        _context = context;
    }

    public ResultDto ChangeIsActiveProduct(int id)
    {
        if (id == 0)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "یافت نشد"
            };
        }

        var product = _context.Products.FirstOrDefault(x => x.ProductId == id);

        if (product == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "یافت نشد"
            };
        }

        if (product.IsActive == true)
        {
            product.IsActive = false;
        }
        else
        {
            product.IsActive = true;
        }

        _context.SaveChanges();
        return new ResultDto
        {
            IsSuccess = true,
            Message = "با موفقیت انجام شد"
        };
    }

    public ResultDto<List<ResultGetProductForAdminDto>> Execute()
    {
        return new ResultDto<List<ResultGetProductForAdminDto>>
        {
            Data = _context.Products
                .Where(x => x.IsRemove == false)
                .Select(x => new ResultGetProductForAdminDto
                {
                    InsertDate = x.InsertDate,
                    IsActive = x.IsActive,
                    ProductDescription = x.ProductDescription,
                    ProductId = x.ProductId,
                    ProductMainPicture = x.ProductMainPicture,
                    ProductName = x.ProductName,
                })
                .ToList(),
            IsSuccess = true,
            Message = ""

        };
    }
}