using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Data.Models
{
    public class MealRating
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
