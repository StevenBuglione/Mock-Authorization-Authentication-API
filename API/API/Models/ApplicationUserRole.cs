using System;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class ApplicationUserRole: IdentityUserRole<int>
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Role Role { get; set; }
    }
}
