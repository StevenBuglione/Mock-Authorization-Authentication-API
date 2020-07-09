using System;
using System.Collections.Generic;
using API.Models;

namespace API.Dtos.AppUserDtos
{
    public class AppUserForDetailedDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
