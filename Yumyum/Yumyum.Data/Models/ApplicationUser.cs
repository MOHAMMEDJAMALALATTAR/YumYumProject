using Microsoft.AspNetCore.Identity;
using Yumyum.Core.Enums;
using Yumyum.Data.Models;

namespace Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public UserType UserType { get; set; }
        public DateTime? DOB { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = String.Empty;
        public List<Order> Orders { get; set; }
        public List<MealRating> MealRatings { get; set; }


    }
}