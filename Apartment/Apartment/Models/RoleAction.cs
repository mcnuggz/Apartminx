using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Apartment.Models
{
    internal class RoleAction
    {
        internal void AddUserAndRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult idRoleResult;
            IdentityResult idUserResult, idUserResult2;

            var roleStore = new RoleStore<IdentityRole>(context);
            var _roleManager = new RoleManager<IdentityRole>(roleStore);
            if (!_roleManager.RoleExists("Admin"))
            {
                idRoleResult = _roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!_roleManager.RoleExists("Landlord"))
            {
                idRoleResult = _roleManager.Create(new IdentityRole { Name = "Landlord" });
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var adminUser = new ApplicationUser
            {
                UserName = "Admin",
                Email = "admin@dccApartments.com"
            };
            idUserResult = userManager.Create(adminUser, "Pa$$word1");

            var landlord1 = new ApplicationUser
            {
                UserName = "DDCA_Mgmt",
                Email = "landlord@dccApartments.com"
            };
            idUserResult2 = userManager.Create(landlord1, "DCCAparts1");


            if (!userManager.IsInRole(userManager.FindByEmail("admin@dccApartments.com").Id, "Admin"))
            {
                idUserResult = userManager.AddToRole(userManager.FindByEmail("admin@dccApartments.com").Id, "Admin");
            }

            if (!userManager.IsInRole(userManager.FindByEmail("landlord@dccApartments.com").Id, "Landlord"))
            {
                idUserResult2 = userManager.AddToRole(userManager.FindByEmail("landlord@dccApartments.com").Id, "Landlord");
            }

        }
    }
}