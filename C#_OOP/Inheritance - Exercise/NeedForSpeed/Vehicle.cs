using System.Runtime.CompilerServices;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public double DefaultFuelConsumption { get; set; } = 1.25;

        public virtual double FuelConsumption
        {
            get { return DefaultFuelConsumption; }
            set { DefaultFuelConsumption = value; }
        }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }

    }
}
