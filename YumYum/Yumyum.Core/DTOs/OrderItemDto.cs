using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.DTOs
{
    public class OrderItemDto
    {
        //public int OrderId { get; set; }
        public int MealId { get; set; }
        public int Quantity { get; set; }
    }
}
