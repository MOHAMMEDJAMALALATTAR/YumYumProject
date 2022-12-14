using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Data.Models
{
    public class Meal : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
        public string? Description { get; set; } = String.Empty;
        public float Price { get; set; }
        public float? DiscountValue { get; set; }
        public Category? Category { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public List<OrderItem> Orders { get; set; }
        public List<MealRating> MealRatings { get; set; }



    }
}
