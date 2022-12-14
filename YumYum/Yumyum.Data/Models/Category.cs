using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Data.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string Description { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
