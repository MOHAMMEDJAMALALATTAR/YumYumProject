using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.DTOs
{
    public class CreateOrderDto
    {
        public string Name { get; set; }
        public string? CustomerId { get; set; }
      

    }
}
