﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfType
{
    internal class Bird : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Bird is flying");
        }
    }
    
}
