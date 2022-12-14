using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.DTOs
{
    public class CreateCategoryDto
    {
        [Required]
        [Display(Name = "Name Of Category")]
        public string Name { get; set; }
        public string Description { get; set; }



    }
}
