using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Resposity.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(UserDto user);

        UserDto GetUser(int id);
    }
}
