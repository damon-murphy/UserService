using UserService.Domain.Interfaces;
using UserService.Resposity.Interfaces;

namespace UserService.Domain
{
    public class UserManager : IUserManager
    {
        public readonly IUserRepository _repository;

        public UserManager(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserDto> CreateUser(UserDto user)
        {
            _repository.CreateUser(user);

            return user;
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user = _repository.GetUser(id);

            return user;
        }

    }
}