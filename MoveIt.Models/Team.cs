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

        public int Id { get; set; }

        [Required]
        [StringLength(GeneralConstants.MAX_TEAM_NAME_LENGTH)]
        public string Name { get; set; }

        public virtual Event Event { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
