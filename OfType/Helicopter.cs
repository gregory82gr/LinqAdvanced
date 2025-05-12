using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfType
{
    internal class Helicopter : IFlyable, IFuelable
    {
        public void Fuel()
        {
            Console.WriteLine("Helicopter is fueling");
        }
        public void Fly()
        {
            Console.WriteLine("Helicopter is flying");
        }
    }
    
}
