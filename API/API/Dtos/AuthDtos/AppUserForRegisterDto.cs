using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.AuthDtos
{
    public class AppUserForRegisterDto
    {
        //This Dto will handle registration requests for the AuthController
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength =4, ErrorMessage ="You must specify password between 4 and 8")]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public DateTime Created { get; set; }

        public AppUserForRegisterDto()
        {
            Created = DateTime.Now;
        }
    }
}
