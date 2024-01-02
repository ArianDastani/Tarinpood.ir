using Application.InterFace;
using Common.DTO;

namespace Application.Services.User;

public class UserServices : IUserServices
{
    private IDatabaseContext _context;
    public UserServices(IDatabaseContext context)
    {
        _context = context;
    }
    public ResultDto Add(string Name, string Password)
    {
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "اطلاعات خواسته شده را وارد نمایید"
            };
        }

        Persistance.Context.User user = new Persistance.Context.User
        {
            UName = Name.Trim().ToLower(),
            UPassword = Password,
            InsertDate = DateTime.Now,
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return new ResultDto
        {
            IsSuccess=true,
            Message="با موفقیت ثبت شد"
        };

    }

    public ResultDto EditUser(int id,string UserName, string Password)
    {
        if (string.IsNullOrWhiteSpace(UserName)|| string.IsNullOrWhiteSpace(Password)||id==0||id==null)
        {
            return new ResultDto
            {
                IsSuccess=false,
                Message="نام یا پسورد را وارد کنید"
            };
        }

        var res = _context.Users.Find(id);

        res.UName = UserName.Trim().ToLower();
        res.UPassword = Password;
        _context.SaveChanges();
        return new ResultDto
        {
            IsSuccess=true,
            Message="با موفقیت انجام شد"
        };

    }

    public ResultDto<List<GetUserDto>> GetAllUser()
    {
        return new ResultDto<List<GetUserDto>>
        {
            Data = _context.Users.Where(x => x.IsRemove == false)
                .Select(x => new GetUserDto
                {
                    UId=x.UId,
                    UName=x.UName,
                    UPassword=x.UPassword,
                    
                }).ToList(), IsSuccess = true,
            Message = ""
        };

    }

    public ResultDto Remove(int id)
    {
        if(id == 0 || id == null)
        {
            return new ResultDto
            {
                IsSuccess=false,
                Message="یافت نشد"
            };
        }

        var user=_context.Users.FirstOrDefault(x=> x.UId == id);
        if(user == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "یافت نشد"
            };
        }

        user.IsRemove = true;
        user.RemoveDate= DateTime.Now;
        _context.SaveChanges();

        return new ResultDto
        {
            IsSuccess=true,
            Message="با موفقیت حذف شد"
        };
    }

    public ResultDto<GetUserDto> UserLogin(string UserName, string Password)
    {
        if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
        {
            return new ResultDto<GetUserDto>
            {
                Data = new GetUserDto
                {

                },
                IsSuccess = false,
                Message = "نام کاربری و کلمه عبور را وارد کنید"

            };

        }

        var user = _context.Users.FirstOrDefault(x => x.UPassword == Password && x.UName == UserName.Trim().ToLower());

        if (user == null) { return new ResultDto<GetUserDto> { IsSuccess = false, Message = "کاربری با این مشخصات یافت نشد" }; }

        return new ResultDto<GetUserDto>
        {
            Data = new GetUserDto
            {
                UId=user.UId,
                UName=user.UName,
                UPassword=user.UPassword,

            }
            ,IsSuccess=true,
            Message="ورود با موفقیت انجام شد"
        };

    }
}