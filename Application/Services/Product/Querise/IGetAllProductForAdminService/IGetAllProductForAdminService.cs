using Common.DTO;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Product.Querise.IGetAllProductForAdminService
{
    public interface IGetAllProductForAdminService
    {
        ResultDto<List<ResultGetProductForAdminDto>> Execute();

        ResultDto ChangeIsActiveProduct(int id);
    }
}
