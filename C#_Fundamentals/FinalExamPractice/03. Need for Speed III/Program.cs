namespace _03._Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split('|');
                cars.Add(new Car(carData[0], int.Parse(carData[1]), int.Parse(carData[2])));
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commands = input.Split((" : "));
                string carName = commands[1];
                Car currentCar = cars.First(x => x.Name == carName);
                int fuel = default;
                switch (commands[0])
                {
                    case "Drive":
                        int distance = int.Parse(commands[2]);
                        fuel = int.Parse(commands[3]);
                        if (currentCar.Fuel < fuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            currentCar.Mileage += distance;
                           

                            currentCar.Fuel -= fuel;
                            Console.WriteLine(
                                $"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                            if (currentCar.Mileage > 100_000)
                            {
                                Console.WriteLine($"Time to sell the {carName}!");
                                cars.Remove(currentCar);
                                
                            }
                        }

                        break;
                    case "Refuel":
                        fuel = int.Parse(commands[2]);
                        if (currentCar.Fuel + fuel > 75)
                        {
                            fuel = 75 - currentCar.Fuel;
                        }

                        currentCar.Fuel += fuel;
                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                        break;
                    case "Revert":
                        int km = int.Parse(commands[2]);
                        currentCar.Mileage -= km;
                        Console.WriteLine($"{carName} mileage decreased by {km} kilometers");
                        if (currentCar.Mileage < 10_000)
                        {
                            currentCar.Mileage = 10_000;
                        }

                        break;
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
    }
    }

    public class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            Name = name;
            Mileage = mileage;
            Fuel = fuel;
        }
        public string Name;
        public int Mileage;
        public int Fuel;
    }
}
