using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Data.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MealId { get; set; }
        public string Meal { get; set; }
        public int Quantity { get; set; }
        public OrderItem()
        {
            Quantity = 1;

        }

    }
}
