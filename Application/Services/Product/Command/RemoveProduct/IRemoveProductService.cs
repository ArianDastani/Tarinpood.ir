using Application.InterFace;
using Common.DTO;


namespace Application.Services.Product.Command.RemoveProduct
{
    public interface IRemoveProductService
    {
        ResultDto Execute(int id);
    }

    public class RemoveProductService : IRemoveProductService
    {
        private IDatabaseContext _context;
        public RemoveProductService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int id)
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

            product.IsRemove = true;
            product.RemoveDate = DateTime.Now;

            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت حذف شد"
            };
        }
    }
}
