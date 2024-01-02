using Application.InterFace;
using Common.DTO;

namespace Application.Services.Product.Querise.IGetAttriputeForAdminService;

public class GetAttriputeForAdminService : IGetAttriputeForAdminService
{
    private IDatabaseContext _databaseContext;
    public GetAttriputeForAdminService(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public ResultDto<List<ResultAttributeDto>> Execute()
    {
        return new ResultDto<List<ResultAttributeDto>>
        {
            Data = _databaseContext.Attributes.Where(x => x.IsRemove == false).Select(x => new ResultAttributeDto
            {
                Id = x.AttributeId,
                Name = x.AttributeName,

            }).ToList(),
            IsSuccess = true,
            Message = ""

        };
    }
}