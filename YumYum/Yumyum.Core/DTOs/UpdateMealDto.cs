using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.DTOs
{
    public class UpdateMealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public float? DiscountValue { get; set; }
        public int CategoryId { get; set; }
    }
}
