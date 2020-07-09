using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class AppRoles: IdentityRole<int>
    {
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
