using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.DTOs
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name Of Category")]
        public string Name { get; set; }
        public string Description { get; set; }



    }
}
