using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.ViewModels
{
   public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DOB { get; set; }
        public string UserType { get; set; }
        public DateTime CreatedAt { get; set; }        
    }
}
