namespace Austins_Blog.Migrations
{
    using Austins_Blog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Austins_Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Austins_Blog.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            #region roleManager
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            if(!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }
            #endregion

            //i need to create afew users that will eventually occupy the roles of either the admin or moderator
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u=>u.Email=="austinpearson52@yahoo.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "austinpearson52@yahoo.com",
                    Email = "austinpearson52@yahoo.com",
                    FirstName = "Austin",
                    LastName = "Pearson",
                    DisplayName = "APears"
                }, "Abc&123!");
            }
            if (!context.Users.Any(u => u.Email == "JoeShmo@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "JoeShmo@Mailinator.com",
                    Email = "JoeShmo@Mailinator.com",
                    FirstName = "Joe",
                    LastName = "Shmo",
                    DisplayName = "JShmo"
                }, "Abc&123!");
            }

            var userId = userManager.FindByEmail("austinpearson52@yahoo.com").Id;
            userManager.AddToRole(userId, "Admin");

            userId = userManager.FindByEmail("JoeShmo@Mailinator.com").Id;
            userManager.AddToRole(userId, "Moderator");
        }
    }
}
