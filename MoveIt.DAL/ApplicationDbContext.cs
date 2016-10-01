using Microsoft.AspNet.Identity.EntityFramework;
using MoveIt.Models;
using System.Data.Entity;

namespace MoveIt.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<TournamentEvent> TournamentEvents { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
