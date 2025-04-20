using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PetByTypeComparer : IComparer<Pet>
    {
        public int Compare(Pet? x, Pet? y)
        {
            return x?.Type.CompareTo(y?.Type) ?? 0;
        }
    }
}
