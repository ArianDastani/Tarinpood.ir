using Common.DTO;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Product.Querise.IGetProductForIndexService
{
    public interface IGetProductForIndexService
    {
        ResultDto<List<GetProductForIndexDto>> Execute();

        ResultDto<GetProductForIndexDto> GetDetailProduct(int id);
    }
}
