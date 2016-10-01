using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            ICollection<Team> teams)
        {
            this.Name = name;
            this.Teams = teams;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual  ICollection<Team> Teams { get; set; }
    }
}
