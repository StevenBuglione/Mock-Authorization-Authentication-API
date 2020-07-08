using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class ApplicationUser: IdentityUser<int>
    {
   
        [Required]
        public string FirstName { get; set; }

   
        [Required]
        public string LastName { get; set; }

        
        [Required]
        public DateTime DOB { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }


    }
}
