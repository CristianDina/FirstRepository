using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext dbContext;
        public UserRepository()
        {
            dbContext = new ApplicationDbContext();
        }
    
        public ApplicationUser GetUser(string userId)
        {
            var user = dbContext.Users.Find(userId);
            return user;
        }
    }
}
