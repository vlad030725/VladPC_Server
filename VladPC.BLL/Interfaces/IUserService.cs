using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;

namespace VladPC.BLL.Interfaces
{
    public interface IUserService
    {
        string GenerateTokenString(LoginUserDto user);
        Task<bool> Login(LoginUserDto user);
        Task<bool> RegisterUser(LoginUserDto user);
    }
}
