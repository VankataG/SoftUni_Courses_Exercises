namespace RawData
{
     class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int nCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < nCars; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];

                int speed = int.Parse(data[1]);
                int power = int.Parse(data[2]);
                Engine engine = new Engine(speed, power);

                int weight = int.Parse(data[3]);
                string type = data[4];
                Cargo cargo = new Cargo(type, weight);

                double t1P = double.Parse(data[5]);
                int t1Y = int.Parse(data[6]);
                double t2P = double.Parse(data[7]);
                int t2Y = int.Parse(data[8]);
                double t3P = double.Parse(data[9]);
                int t3Y = int.Parse(data[10]);
                double t4P = double.Parse(data[11]);
                int t4Y = int.Parse(data[12]);
                Tire[] tires = new Tire[4]
                {
                    new Tire(t1P, t1Y),
                    new Tire(t2P, t2Y),
                    new Tire(t3P, t3Y),
                    new Tire(t4P, t4Y),
                };

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string filter = Console.ReadLine();
            switch (filter)
            {
                case "fragile":
                    foreach (var car in cars.Where(x => x.Cargo.Type == filter))
                    {
                        bool toPrint = false;
                        foreach (var tire in car.Tires)
                        {
                            if (tire.Pressure < 1)
                            {
                                toPrint = true;
                            }

                            if (toPrint) break;
                        }

                        if (toPrint)
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                    break;

                case "flammable":
                    foreach (var car in cars
                                 .Where(x => x.Cargo.Type == filter)
                                 .Where(x => x.Engine.Power > 250))
                    {
                            Console.WriteLine(car.Model);
                    }
                    break;
            }
        }
    }
}
