using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodStrings
{
    public class Box<T> where T : IComparable
    {
        public Box()
        {
            Values = new List<T>();
        }
        public List<T> Values { get; set; }

        public int CountOfGreaterElements(T comparer)
        {
            int count = 0;

            foreach (var value in Values)
            {
                if (value.CompareTo(comparer) > 0)
                    count++;
            }

            return count;
        }
    }
}
