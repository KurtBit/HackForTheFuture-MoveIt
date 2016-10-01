using MoveIt.Models;
using System;

namespace MoveIt.DAL.Repositories
{
    public class TeamRepository : RepositoryBase<Team>
    {
        public TeamRepository(ApplicationDbContext context)
            : base(context)
        {
            if(context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
