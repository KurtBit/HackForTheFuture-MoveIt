namespace MoveIt.DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
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

            if (!context.Users.Any())
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
            }
#endif
        }
    }
}

