using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.DAL.Models;

namespace VladPC.BLL.Interfaces
{
    public interface IUserService
    {
        Task<string> GenerateTokenString(string userName);
        //Task<IList<string>> GetRoles(User user);
        //Task<User> GetUserByName(string userName);
        Task<bool> Login(LoginUserDto user);
        Task<bool> RegisterUser(LoginUserDto user);
    }
}
