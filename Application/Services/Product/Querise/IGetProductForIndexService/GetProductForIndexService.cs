using Application.InterFace;
using Common.DTO;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Product.Querise.IGetProductForIndexService;

public class GetProductForIndexService : IGetProductForIndexService
{
    private IDatabaseContext _databaseContext;
    public GetProductForIndexService(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public ResultDto<List<GetProductForIndexDto>> Execute()
    {


        var res = _databaseContext.Products
            .Include(x => x.ProductAttributes)
            .ThenInclude(x => x.Attribute)
            .Where(x => x.IsRemove == false)
            .Where(x => x.IsActive == true)
            .Select(x => new GetProductForIndexDto
            {
                ProductDescription = x.ProductDescription,
                ProductId = x.ProductId,
                ProductMainPicture = x.ProductMainPicture,
                ProductName = x.ProductName,


            }).ToList();

        return new ResultDto<List<GetProductForIndexDto>>
        {
            Data = res,
            IsSuccess = true,
            Message = ""

        };

    }

    public ResultDto<GetProductForIndexDto> GetDetailProduct(int id)
    {
        if (id == 0 || id == null)
        {
            return new ResultDto<GetProductForIndexDto>
            {
                IsSuccess = false,
                Message = "یافت نشد"
            };
        }


        var product = _databaseContext.Products
            .Where(x => x.IsRemove == false)
            .Include(x => x.ProductAttributes)
            .FirstOrDefault(x => x.ProductId == id);

        if (product == null)
        {
            return new ResultDto<GetProductForIndexDto>
            {
                IsSuccess = false,
                Message = "یافت نشد"
            };
        }

        var productAtt = _databaseContext.ProductAttributes
            .Include(x => x.Attribute)
            .Where(x => x.ProductId == product.ProductId)
            .Select(x => new AttributeIndexDto { AttributeName = x.Attribute.AttributeName, AttributeNameContent = x.ProductAttributeContent })
            .ToList();

        var res = _databaseContext.Products
            .Include(x => x.ProductAttributes)
            .Where(x => x.IsRemove == false)
            .OrderByDescending(x => x.InsertDate)
            .Take(4)
            .Select(x => new GetProductForIndexDto
            {
                ProductDescription = x.ProductDescription,
                ProductId = x.ProductId,
                ProductMainPicture = x.ProductMainPicture,
                ProductName = x.ProductName,


            }).ToList();

        GetProductForIndexDto getProductForIndexDto = new GetProductForIndexDto
        {
            ProductMainPicture = product.ProductMainPicture,
            ProductDescription = product.ProductDescription,
            ProductName = product.ProductName,

            ProductAttributes = productAtt,

            LastProduct = res,
        };



        return new ResultDto<GetProductForIndexDto>
        {
            Data = getProductForIndexDto
            ,
            Message = "",
            IsSuccess = true

        };
    }
}