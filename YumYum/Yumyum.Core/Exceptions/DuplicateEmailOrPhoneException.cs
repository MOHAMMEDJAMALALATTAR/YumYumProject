﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.Exceptions
{
   public class DuplicateEmailOrPhoneException : Exception
    {
        public DuplicateEmailOrPhoneException(): base("Duplicate Email Or Phone Exception")
        {

        }
    }
}
