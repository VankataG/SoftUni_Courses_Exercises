using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {

        }
        public string Name { get; set; }
        public int Age { get; set; }
        
    }
}
