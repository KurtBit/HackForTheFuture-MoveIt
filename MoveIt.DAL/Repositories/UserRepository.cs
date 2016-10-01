using MoveIt.Models;
using System;

namespace MoveIt.DAL.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
            if(context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
