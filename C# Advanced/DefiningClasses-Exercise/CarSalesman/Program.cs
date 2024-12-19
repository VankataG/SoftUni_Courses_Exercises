using System.ComponentModel.Design;

namespace CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] engInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                GetEngine(engInfo, engines);
            }

            List<Car> cars = new List<Car>();

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

               GetCar(carInfo, cars , engines);
            }

            foreach (Car car in cars)
            {
               Console.WriteLine(car);
            }
        }

        static void GetEngine(string[] engInfo, Dictionary<string, Engine> engines)
        {
            string model = engInfo[0];
            int power = int.Parse(engInfo[1]);
            Engine engine = new Engine(model, power);

            if (engInfo.Length > 2)
            {
                if (int.TryParse(engInfo[2], out int displacement))
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = engInfo[2];
                }
            }
            if (engInfo.Length > 3)
            {
                string efficiency = engInfo[3];
                engine.Efficiency = efficiency;
            }

            if (!engines.ContainsKey(model))
            {
                engines[model] = engine;
            }
        }

        static void GetCar(string[] carInfo, List<Car> cars, Dictionary<string, Engine> engines)
        {
            string model = carInfo[0];
            Engine engine = engines[carInfo[1]];
            Car car = new Car(model, engine);

            if (carInfo.Length > 2)
            {
                if (int.TryParse(carInfo[2], out int weight))
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = carInfo[2];
                }
            }

            if (carInfo.Length > 3)
            {
                string color = carInfo[3];
                car.Color = color;
            }

            cars.Add(car);
        }
    }
}
