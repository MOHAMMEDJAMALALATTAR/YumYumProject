﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yumyum.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() :base("Item Not Found")
        {
            
            

        }

    }
}
