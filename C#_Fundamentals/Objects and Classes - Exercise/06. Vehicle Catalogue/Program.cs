namespace _06._Vehicle_Catalogue
{

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new();
            string input;
            int vehicleCount = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                vehicleCount++;
                if (vehicleCount > 50)
                    break;
                string[] infos = input.Split();
                vehicles.Add(new Vehicle(infos[0], infos[1], infos[2], decimal.Parse(infos[3])));
            }
            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (Vehicle x in vehicles)
                {
                    if (x.Type == "car") x.Type = "Car";
                    else if (x.Type == "truck") x.Type = "Truck";
                    if (input == x.Model)
                    {
                        Console.WriteLine($"Type: {x.Type}\n" +
                            $"Model: {x.Model}\n" +
                            $"Color: {x.Color}\n" +
                            $"Horsepower: {x.HP}");
                    }
                }
            }
            decimal averageCars = 0;
            decimal averageTrucks = 0;
            decimal countCars = 0;
            decimal countTrucks = 0;
            foreach (Vehicle x in vehicles)
            {
                if (x.Type == "Car")
                {
                    countCars++;
                    averageCars += x.HP;
                }
                else if (x.Type == "Truck")
                {
                    countTrucks++;
                    averageTrucks += x.HP;
                }
            }
            if (countCars > 0)
            {
                averageCars /= countCars;
            }

            Console.WriteLine($"Cars have average horsepower of: {averageCars:f2}.");

            if (countTrucks > 0)
            {
                averageTrucks /= countTrucks;
            }
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucks:f2}.");

        }
    }
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, decimal hP)
        {
            Type = type;
            Model = model;
            Color = color;
            HP = hP;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal HP { get; set; }

    }

}
