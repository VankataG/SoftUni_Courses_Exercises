namespace NeedForSpeed
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int horsePower, double fuel)
        : base(horsePower, fuel) { }

        public override double FuelConsumption
        {
            get { return DefaultFuelConsumption; }
            set { DefaultFuelConsumption = value;}
        }
    }
}
