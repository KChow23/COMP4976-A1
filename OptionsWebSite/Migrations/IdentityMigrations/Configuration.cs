namespace OptionsWebSite.Migrations.IdentityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OptionsWebSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\IdentityMigrations";
            ContextKey = "OptionsWebSite.Models.ApplicationDbContext";
        }

        protected override void Seed(OptionsWebSite.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(t => t.UserName == "A00111111"))
            {
                var user = new ApplicationUser { UserName = "A00111111", Email = "a@a.a" };
                userManager.Create(user, "P@$$w0rd");

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(t => t.UserName == "A00222222"))
            {
                var user = new ApplicationUser { UserName = "A00222222", Email = "s@s.s" };
                userManager.Create(user, "P@$$w0rd");

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Student" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Student");
            }
        }
    }
}
