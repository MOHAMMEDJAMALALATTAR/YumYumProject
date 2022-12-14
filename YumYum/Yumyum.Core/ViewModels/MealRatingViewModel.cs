using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.ViewModels
{
    public class MealRatingViewModel
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public MealViewModel Meal { get; set; }
    }
}
