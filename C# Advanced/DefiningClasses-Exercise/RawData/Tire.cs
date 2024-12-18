using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
     class Tire
    {
        public Tire(double pressure, int age)   
        {
            Pressure = pressure;
            Age = age;
        }
        public int Age { get; set; }
        public double Pressure { get; set; }

    }
}
