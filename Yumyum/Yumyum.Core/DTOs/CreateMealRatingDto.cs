using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yumyum.Core.ViewModels;

namespace Yumyum.Core.DTOs
{
    public class CreateMealRatingDto
    {
        public int Stars { get; set; }
        public string ApplicationUserId { get; set; }
        public int MealId { get; set; }
    }
}
