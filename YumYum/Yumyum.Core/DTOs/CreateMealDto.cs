using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.DTOs
{
    public class CreateMealDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public float? DiscountValue { get; set; }
        public int CategoryId { get; set; }
    }
}
