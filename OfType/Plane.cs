using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfType
{
    internal class Plane : IFlyable, IFuelable
    {
        public void Fuel()
        {
            Console.WriteLine("Plane is fueling");
        }
    
        public void Fly()
        {
            Console.WriteLine("Plane is flying");
        }
    }
   
}
