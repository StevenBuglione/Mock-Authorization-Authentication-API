using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class AppUser: IdentityUser<int>
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }


    }
}
