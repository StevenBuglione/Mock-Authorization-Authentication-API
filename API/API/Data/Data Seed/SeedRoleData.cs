using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class SeedRoleData
    {
        public static void SeedUserRoleData(UserManager<AppUser> userManager, RoleManager<AppRoles> roleManager)
        {

            if (!userManager.Users.Any())
            {
                //create some roles
                var roles = new List<AppRoles>
                {
                    new AppRoles{Name = "Member"},
                    new AppRoles{Name = "Admin"},
                    new AppRoles{Name = "Moderator"},
                    new AppRoles{Name = "VIP"}
                };

                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role).Wait();
                }

                var adminUser = new AppUser
                {
                    UserName = "Admin",
                    FirstName = "Steven",
                    LastName = "Buglione",
                    DOB = Convert.ToDateTime("07/29/1999")
                };

                var result = userManager.CreateAsync(adminUser, "password").Result;

                if (result.Succeeded)
                {
                    var admin = userManager.FindByNameAsync("Admin").Result;
                    userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
                }
            }
        }


    }
  
}
