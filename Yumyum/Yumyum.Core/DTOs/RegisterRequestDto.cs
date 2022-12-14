using System.ComponentModel.DataAnnotations;
using Yumyum.Core.Enums;

namespace Yumyum.Core.DTOs
{
    public class RegisterRequestDto
    {

        [Required]
        [EmailAddress]
        [Display(Name = " The Email Address ")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Phone]
        [Display(Name = "PhoneNumber ")]
        public string PhoneNumber { get; set; }
        [Required]
        public string FullName { get; set; }
        [Display(Name = "User Type")]
        public UserType UserType { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }


    }
}
