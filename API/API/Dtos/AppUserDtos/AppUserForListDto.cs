using System;
namespace API.Dtos.AppUserDtos
{
    public class AppUserForListDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime Created { get; set; }
    }
}
