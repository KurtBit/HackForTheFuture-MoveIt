﻿using System;
using System.Collections.Generic;

namespace MoveIt.Models
{
    public class TournamentEvent
    {
        public TournamentEvent()
        {
            this.Teams = new HashSet<Team>();
        }

        public TournamentEvent(
            string name,
            ICollection<Team> teams,
            string description,
            DateTime startDate,
            DateTime endDate)
        {
            this.Name = name;
            this.Teams = teams;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual  ICollection<Team> Teams { get; set; }
    }
}
