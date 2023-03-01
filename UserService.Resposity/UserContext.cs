using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Resposity
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
        : base(options)
        {
        }
        public virtual DbSet<UserDto> Users { get; set; }
    }
}
