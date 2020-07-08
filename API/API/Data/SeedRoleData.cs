using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class SeedRoleData
    {
        public static void SeedUserRoleData(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager)
        {
            //create some roles
            var roles = new List<Role>
                {
                    new Role{Name = "Member"},
                    new Role{Name = "Admin"},
                    new Role{Name = "Moderator"},
                    new Role{Name = "VIP"}
                };

            foreach (var role in roles)
            {
                roleManager.CreateAsync(role).Wait();
            }

            var adminUser = new ApplicationUser
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
