using System.Collections.Generic;

namespace MoveIt.Models
{
    public class Event
    {
        public Event()
        {
            this.Teams = new HashSet<Team>();
        }

        public int Id { get; set; }

        public virtual  ICollection<Team> Teams { get; set; }
    }
}
