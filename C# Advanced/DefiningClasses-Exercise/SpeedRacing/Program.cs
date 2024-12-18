namespace SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> carsMap = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumprtionForKm = double.Parse(carData[2]);

                if (!carsMap.ContainsKey(model))
                {
                    carsMap.Add(model, new Car(model, fuelAmount, fuelConsumprtionForKm));
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = commands[1];
                double km = double.Parse(commands[2]);

                carsMap[model].Drive(km);
            }

            foreach (var car in carsMap.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
