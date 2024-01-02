using Common.DTO;
using Persistance.Context;

namespace Application.Services.User
{
    public interface IUserServices
    {
        ResultDto Add(string Name, string Password);
        ResultDto Remove(int id);
        ResultDto<List<GetUserDto>> GetAllUser();
        ResultDto<GetUserDto> UserLogin(string UserName, string Password);
ResultDto EditUser(int id,string UserName, string Password);

    }
}
