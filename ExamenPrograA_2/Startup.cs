using ExamenPrograA_2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenPrograA_2.Startup))]
namespace ExamenPrograA_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // En el caso de que primero se cree la aplicación, cree el rol de administrador y un usuario de administrador predeterminado
            if (!roleManager.RoleExists("Admin"))
            {
                // Crear rol de administrador
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Crear un usuario de administrador predeterminado
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                string userPWD = "P455w0rd$";
                var chkUser = userManager.Create(user, userPWD);

                // Añadir el usuario admin al rol de administrador
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            // Crear otros roles aquí si es necesario...
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }
    }
}