using UserService.Resposity.Interfaces;

namespace UserService.Resposity
{
    public class UserRepository : IUserRepository
    {
        public readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public void CreateUser(UserDto user)
        {
            _context.Set<UserDto>().Add(user);
            _context.SaveChanges();
        }

        public UserDto GetUser(int id)
        {
            var user = _context.Set<UserDto>().Find(id);
            _ = _context.Attach<UserDto>(user);
            return user;
        }
    }
}