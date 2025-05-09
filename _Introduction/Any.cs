using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Introduction
{
    public static  class Any
    {
        public  static bool IsAny( int[] numbers, Func<int,bool> predicate)
        {
            foreach(var number in numbers)
            {
                if (predicate(number))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsAny<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsAnyAsExtension<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
