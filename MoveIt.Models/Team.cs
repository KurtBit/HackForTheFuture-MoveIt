using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoveIt.Models
{
    public class Team
    {
        public Team()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public Team(string name, TournamentEvent tournamentEvent, ICollection<ApplicationUser> users)
        {
            this.Name = name;
            this.TournamentEvent = tournamentEvent;
            this.Users = users;
        }

        public int Id { get; set; }

        public int TournamentEventId { get; set; }

        [Required]
        [StringLength(GeneralConstants.MAX_TEAM_NAME_LENGTH)]
        public string Name { get; set; }

        public virtual TournamentEvent TournamentEvent { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
