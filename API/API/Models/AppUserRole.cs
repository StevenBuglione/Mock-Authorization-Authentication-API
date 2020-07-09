using System;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class AppUserRole: IdentityUserRole<int>
    {
        public virtual AppUser AppUser { get; set; }
        public virtual AppRoles AppRoles { get; set; }
    }
}
