using Application.InterFace;
using Common.DTO;
using Common.SaveFile;
using Microsoft.AspNetCore.Http;
using Persistance.Context;


namespace Application.Services.Product.Command.AddProduct
{
    public interface IAddProductService
    {
        ResultDto Execute(AddProductDto productDto, IFormFile ImageMain, List<ProductFeatures> productFeatures);

        ResultDto<EditProductDto> FillProduct(int ProductId);
    }

    public class AddProductService : IAddProductService
    {
        private IDatabaseContext _context;
        public AddProductService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<EditProductDto> FillProduct(int ProductId)
        {
            if (ProductId == 0)
            {
                return new ResultDto<EditProductDto> { Data = new EditProductDto { ProductId = 0 } };
            }

            var product = _context.Products.Find(ProductId);

            var productfea = _context.ProductAttributes
                .Where(x => x.ProductId == ProductId)
                .Select(x => new ProductFeatures
                {
                    DisplayName = x.ProductAttributeContent,
                    Value = x.AttributeId.ToString()
                }).ToList();

            if (product == null)
            {
                return new ResultDto<EditProductDto> { Data = new EditProductDto { ProductId = 0 } };
            }

            return new ResultDto<EditProductDto>
            {
                Data = new EditProductDto
                {
                    Description = product.ProductDescription,
                    Images = product.ProductMainPicture,
                    Name = product.ProductName,
                    ProductId = product.ProductId,
                    ProductFeatures = productfea,
                },
                IsSuccess = true,

                Message = ""
            };
        }

        public ResultDto Execute(AddProductDto productDto, IFormFile ImageMain, List<ProductFeatures> productFeatures)
        {
            if (productDto.ProductId == 0 || productDto.ProductId == null)
            {
                if (
               productFeatures == null ||
               string.IsNullOrWhiteSpace(productDto.Description) ||
               string.IsNullOrWhiteSpace(productDto.Name))
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "اطلاعات مورد نیاز را وارد کنید"
                    };
                }

                if (ImageMain == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "تصویر اصلی پروژه را وارد کنید"
                    };
                }

                string Main = "";
                //List<string> Imagess = new List<string>();

                if (ImageMain != null)
                {
                    Main = Guid.NewGuid().ToString("N") + Path.GetExtension(ImageMain.FileName);
                    ImageMain.AddImageAjaxToServer(Main, $"{Directory.GetCurrentDirectory()}/wwwroot/content/product/");
                }

                //if (Images != null)
                //{
                //    foreach (var item in Images)
                //    {

                //    }
                //}

                Persistance.Context.Product product = new Persistance.Context.Product
                {
                    IsActive = true,
                    InsertDate = DateTime.Now,
                    ProductDescription = productDto.Description,
                    ProductMainPicture = Main,
                    ProductName = productDto.Name,
                    UId = 5412635

                };

                _context.Products.Add(product);
                _context.SaveChanges();

                List<ProductAttribute>? ProductAttributes = new List<ProductAttribute>();

                var att = _context.Attributes.FirstOrDefault(x => x.AttributeName == "جنس");

                foreach (var item in productFeatures)
                {
                    var attribute = _context.Attributes.FirstOrDefault(x => x.AttributeName == item.DisplayName.Trim());

                    ProductAttributes.Add(new ProductAttribute
                    {
                        AttributeId = attribute.AttributeId,
                        InsertDate = DateTime.Now,
                        Product = product,
                        ProductAttributeContent = item.Value,
                    });

                }

                _context.ProductAttributes.AddRange(ProductAttributes);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت ثبت شد"
                };
            }
            else
            {
                var product = _context.Products.Find(productDto.ProductId);

                var productfea = _context.ProductAttributes
                    .Where(x => x.ProductId == productDto.ProductId)
                    .Select(x => new ProductFeatures
                    {
                        DisplayName = x.ProductAttributeContent,
                        Value = x.AttributeId.ToString()
                    }).ToList();

                string imagename = product.ProductMainPicture;

                product.ProductName = productDto.Name;
                product.ProductDescription = productDto.Description;

                if (ImageMain != null)
                {
                    imagename = Guid.NewGuid().ToString("N") + Path.GetExtension(ImageMain.FileName);
                    ImageMain.AddImageAjaxToServer(imagename, $"{Directory.GetCurrentDirectory()}/wwwroot/content/product/");
                }

                product.ProductMainPicture = imagename;

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت ویرایش شد"
                };
            }


        }
    }

    public class AddProductDto
    {
        public int? ProductId { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public IFormFile? Images { get; set; }

        public bool? IsActive { get; set; }


    }

    public class ProductFeatures
    {
        public string? DisplayName { get; set; }
        public string? Value { get; set; }
    }

    public class EditProductDto
    {
        public int? ProductId { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Images { get; set; }

        public List<ProductFeatures>? ProductFeatures { get; set; }
    }
}
