namespace _03._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] datas = Console.ReadLine().Split();
                cars.Add(new Car(datas[0], double.Parse(datas[1]), double.Parse(datas[2])));
            }
            string input;
            while ((input = Console.ReadLine())  != "End")
            {
                string[] datas = input.Split();
                if (datas[0] == "Drive")
                {
                    string model = datas[1];
                    int Km = int.Parse(datas[2]);

                    foreach (Car car in cars)
                    {
                        car.Travel(model, Km);
                    }
                }
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.Fuel:f2} {car.TravelledDistance}");
            }
        }
    }
    public class Car
    {
        public Car(string model, double fuel, double fuelPerKm)
        {
            Model = model;
            Fuel = fuel;
            FuelPerKm = fuelPerKm;
        }
        public string Model;
        public double Fuel;
        public double FuelPerKm;
        public int TravelledDistance;

        public void Travel(string model, int km)
        {
            if (Model == model)
            {
                if ((Fuel / FuelPerKm) >= km)
                {
                    TravelledDistance += km;
                    Fuel -= km * FuelPerKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
        }
    }

}
