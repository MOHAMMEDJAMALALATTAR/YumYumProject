using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.ViewModels
{
    public class MealViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; } 
        public string? Description { get; set; } 
        public float Price { get; set; }
        public float? DiscountValue { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
