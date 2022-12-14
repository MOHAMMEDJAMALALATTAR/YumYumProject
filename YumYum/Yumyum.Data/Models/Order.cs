using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Data.Models
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser Customer { get; set; }
        [ForeignKey("ApplicationUserId")]
        public string? CustomerId { get; set; }
        public List<OrderItem> Orders { get; set; }

    }
}
