using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PetComparerById : IEqualityComparer<Pet>
    {
        bool IEqualityComparer<Pet>.Equals(Pet? x, Pet? y)
        {
            return x.Id==y.Id;
        }

        int IEqualityComparer<Pet>.GetHashCode(Pet obj)
        {
            return obj.Id;
        }
    }
}
