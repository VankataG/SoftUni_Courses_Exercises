using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    internal class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = 0;
            Color = "n/a";
        }
        public string Model {  get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            string weight = Weight != 0 ? Weight.ToString() : "n/a";
            return $"{Model}:\n" +
                $"{Engine}\n" +
                $"Weight: {weight}\n" +
                $"Color: {Color}";
        }
    }
}
