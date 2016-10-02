using System;
using System.Collections.Generic;

namespace MoveIt.WebUi.ViewModels
{
    using Models;
    using System.Linq.Expressions;

    public class TeamViewModel
    {
        public static Expression<Func<Team, TeamViewModel>> FromTeam
        {
            get
            {
                return team => new TeamViewModel()
                {
                    Id = team.Id,
                    Name = team.Name,
                    Users = team.Users
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}