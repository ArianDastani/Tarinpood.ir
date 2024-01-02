using Application.InterFace;
using Common.DTO;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Application.Services.Product.Command.AddAttripute
{
    public interface IAddAttriputeService
    {
        ResultDto Execute(RequestAddAttributeDto attributeDto);
        ResultDto<List<AttributeDto>> GetAllAttributeDto();
        ResultDto Remove(int Id);
        ResultDto RemoveAtt(int Id);

        ResultDto<List<GetAllAttributeProductDto>> GetAllAttributeProductDto(int Id);
        ResultDto EditAttributeProduct(int id, string name);

        ResultDto AddProductAttribute(int Productid, string AttributeName, string AttributeContent);
    }

    public class AddAttriputeService : IAddAttriputeService
    {
        private IDatabaseContext _databaseContext;
        public AddAttriputeService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ResultDto AddProductAttribute(int Productid, string AttributeName, string AttributeContent)
        {
            var Cuurentproduct = _databaseContext.Products.FirstOrDefault(x => x.ProductId == Productid);
            var Attribute = _databaseContext.Attributes.FirstOrDefault(x => x.AttributeName == AttributeName.Trim());

            ProductAttribute productAttribute = new ProductAttribute
            {
                InsertDate = DateTime.Now,
                AttributeId = Attribute.AttributeId,
                ProductAttributeContent = AttributeContent,
                ProductId = Cuurentproduct.ProductId,

            };

            _databaseContext.ProductAttributes.Add(productAttribute);
            _databaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "با موفقیت ثبت شد"
            };



        }

        public ResultDto EditAttributeProduct(int id, string name)
        {
            if (id == 0 || id == null || name == null || name == "")
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "یافت نشد"
                };
            }

            var att = _databaseContext.ProductAttributes.FirstOrDefault(x => x.ProductAttributeId == id);

            if (att == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "یافت نشد"
                };
            }

            att.ProductAttributeContent = name;
            _databaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "با موفقیت ویرایش شد"
            };
        }

        public ResultDto Execute(RequestAddAttributeDto attributeDto)
        {
            if (string.IsNullOrWhiteSpace(attributeDto.AttributeName))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نام ویژگی را وارد کنید"
                };
            }

            Persistance.Context.Attribute attribute = new Persistance.Context.Attribute()
            {
                InsertDate = DateTime.Now,
                AttributeName = attributeDto.AttributeName,
            };

            _databaseContext.Attributes.Add(attribute);
            _databaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "با موفقیت ثبت شد"
            };
        }

        public ResultDto<List<AttributeDto>> GetAllAttributeDto()
        {
            return new ResultDto<List<AttributeDto>>
            {
                Data = _databaseContext.Attributes
                .Where(x => x.IsRemove == false)
                .Select(x => new AttributeDto
                {
                    Id = x.AttributeId,
                    Name = x.AttributeName,
                }).ToList(),
                IsSuccess = true
                ,
                Message = ""

            };
        }

        public ResultDto<List<GetAllAttributeProductDto>> GetAllAttributeProductDto(int Id)
        {
            return new ResultDto<List<GetAllAttributeProductDto>>
            {
                Data = _databaseContext.ProductAttributes
                .Include(x => x.Attribute)
                .Where(x => x.ProductId == Id)
                .Select(x => new GetAllAttributeProductDto
                {
                    AttributeId = x.Attribute.AttributeId,
                    AttributeName = x.Attribute.AttributeName,
                    ProductAttributeContent = x.ProductAttributeContent,
                    ProductAttributeId = x.ProductAttributeId,
                }).ToList(),
                IsSuccess = true,
                Message = ""
            };
        }

        public ResultDto Remove(int Id)
        {
            if (Id == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false
                    ,
                    Message = "یافت نشد"
                };
            }

            var res = _databaseContext.Attributes.FirstOrDefault(x => x.AttributeId == Id);

            if (res == null)
            {
                return new ResultDto
                {
                    IsSuccess = false
                    ,
                    Message = "یافت نشد"
                };
            }

            res.IsRemove = true;
            res.RemoveDate = DateTime.Now;
            _databaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "با موفقیت حذف شد"
            };
        }

        public ResultDto RemoveAtt(int Id)
        {
            if (Id == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false
                    ,
                    Message = "یافت نشد"
                };
            }

            var res = _databaseContext.ProductAttributes.FirstOrDefault(x => x.ProductAttributeId == Id);

            if (res == null)
            {
                return new ResultDto
                {
                    IsSuccess = false
                    ,
                    Message = "یافت نشد"
                };
            }

            _databaseContext.ProductAttributes.Remove(res);
            _databaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "با موفقیت حذف شد"
            };
        }

    }

    public class RequestAddAttributeDto
    {
        public string? AttributeName { get; set; }
    }

    public class AttributeDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }

    public class GetAllAttributeProductDto
    {
        public int? ProductAttributeId { get; set; }
        public string? ProductAttributeContent { get; set; }
        public string? AttributeName { get; set; }
        public int? AttributeId { get; set; }
    }
}
