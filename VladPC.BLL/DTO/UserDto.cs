using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Models;

namespace VladPC.BLL.DTO
{
    public class UserDto
    {
        public UserDto(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            //Password = user.PasswordHash;
        }

        public UserDto() { }

        public int Id { get; set; }

        public string Role { get; set; }

        public string UserName { get; set; }

        //public string Password { get; set; }
    }
}
