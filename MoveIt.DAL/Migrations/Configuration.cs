namespace MoveIt.DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoveIt.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
#if DEBUG
            const string password = "123456";

            if (!context.Users.Any() ||
                !context.TournamentEvents.Any())
            {
                #region Users

                var passwordHasher = new PasswordHasher();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var owner = new ApplicationUser
                {
                    UserName = "Dominent",
                    Email = "petromilpavlov@gmail.com",
                    PasswordHash = passwordHasher.HashPassword(password),
                };

                userManager.Create(owner);

                context.SaveChanges();

                #endregion

                #region Events

                var tournamentEvents = new List<TournamentEvent>()
                {
                    new TournamentEvent("Custom Event 1", new HashSet<Team>(), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."),
                    new TournamentEvent("Custom Event 2", new HashSet<Team>(), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."),
                    new TournamentEvent("Custom Event 3", new HashSet<Team>(), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."),
                    new TournamentEvent("Custom Event 4", new HashSet<Team>(),"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."),
                    new TournamentEvent("Custom Event 5",  new HashSet<Team>(),"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."),
                };

                foreach (var tournamentEvent in tournamentEvents)
                {
                    context.TournamentEvents.Add(tournamentEvent);
                }

                context.SaveChanges();

                #endregion

                #region Teams

                var teams = new List<Team>()
                {
                    new Team("Unknown 1", tournamentEvents[0], new List<ApplicationUser>() {owner}),
                    new Team("Unknown 2", tournamentEvents[1], new List<ApplicationUser>() {owner}),
                    new Team("Unknown 3", tournamentEvents[2], new List<ApplicationUser>() {owner}),
                    new Team("Unknown 4", tournamentEvents[3], new List<ApplicationUser>() {owner}),
                };

                foreach (var team in teams)
                {
                    context.Teams.Add(team);
                }

                context.SaveChanges();

                #endregion
            }
#endif
        }
    }
}

