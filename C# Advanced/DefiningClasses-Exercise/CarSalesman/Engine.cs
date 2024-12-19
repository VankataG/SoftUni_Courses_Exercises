using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    internal class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = 0;
            Efficiency = "n/a";
        }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            string displacement = Displacement != 0 ? Displacement.ToString() : "n/a";
            return $"{Model}:\n" +
                   $"Power: {Power}\n" +
                   $"Displacement: {displacement}\n" +
                   $"Efficiency: {Efficiency}";
        }
    }
}
