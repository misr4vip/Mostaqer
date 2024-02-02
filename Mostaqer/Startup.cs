using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Mostaqer.Models;
using Owin;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Mostaqer.Startup))]
namespace Mostaqer
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdministrator();
            CreateRoles();
        }
        public void CreateAdministrator()
        {
            var superAdmin = db.Users.Where(u => u.UserName.Equals("Administrator")).ToList().FirstOrDefault();
            if (superAdmin == null)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var user = new ApplicationUser();
                user.UserName = "Administrator";
                user.PhoneNumber = "0534426545";
                user.PhoneNumberConfirmed = true;
                user.Email = "fayez.elghoul@gmail.com";
                user.EmailConfirmed = true;
                var check = userManager.Create(user, "Qa123456@");

                  

            }

        }
       
            public void CreateRoles()
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                IdentityRole role;
               
                if (!roleManager.RoleExists("admin"))
                {
                    role = new IdentityRole();
                    role.Name = "admin";
                    roleManager.Create(role);
                }
                if (!roleManager.RoleExists("owner"))
                {
                    role = new IdentityRole();
                    role.Name = "owner";
                    roleManager.Create(role);
                }
                if (!roleManager.RoleExists("user"))
                {
                    role = new IdentityRole();
                    role.Name = "user";
                    roleManager.Create(role);
                }
               
            }
        
    }
}
