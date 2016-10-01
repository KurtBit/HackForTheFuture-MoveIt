using MoveIt.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MoveIt.WebUi.ViewModels
{
    public class TournamentEventViewModel
    {
        public static Expression<Func<TournamentEvent, TournamentEventViewModel>> FromTournamentEvent
        {
            get
            {
                return tournamentEvent => new TournamentEventViewModel()
                {
                   Id = tournamentEvent.Id,
                   Name = tournamentEvent.Name,
                   Teams = tournamentEvent.Teams
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Team> Teams { get; set; }
    }
}