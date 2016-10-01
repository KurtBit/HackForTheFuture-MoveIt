using MoveIt.Models;
using System;

namespace MoveIt.DAL.Repositories
{
    public class TournamentEventReposiotry : RepositoryBase<TournamentEvent>
    {
        public TournamentEventReposiotry(ApplicationDbContext context)
            : base(context)
        {
            if(context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
