using Common.DTO;


namespace Application.Services.Product.Querise.IGetAttriputeForAdminService
{
    public interface IGetAttriputeForAdminService
    {
        ResultDto<List<ResultAttributeDto>> Execute();
    }
}
