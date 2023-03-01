using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Interfaces
{
    public interface IUserManager
    {
        Task<UserDto> CreateUser(UserDto user);

        Task<UserDto> GetUser(int id);
    }
}
