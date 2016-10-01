using MoveIt.Models;
using System;

namespace MoveIt.DAL.Repositories
{
    public class EventReposiotry : RepositoryBase<Event>
    {
        public EventReposiotry(ApplicationDbContext context)
            : base(context)
        {
            if(context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
