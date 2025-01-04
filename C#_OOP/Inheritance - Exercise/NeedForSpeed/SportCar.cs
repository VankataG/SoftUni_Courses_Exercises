namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            DefaultFuelConsumption = 10;
        }

        public override double FuelConsumption
        {
            get { return DefaultFuelConsumption; }
            set { DefaultFuelConsumption = value; }
        }
    }
}
