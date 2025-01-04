namespace NeedForSpeed
{
    public class FamilyCar : Car
    {
        public FamilyCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
      
        }

        public override double FuelConsumption
        {
            get { return DefaultFuelConsumption; }
            set { DefaultFuelConsumption = value; }
        }
    }
}
