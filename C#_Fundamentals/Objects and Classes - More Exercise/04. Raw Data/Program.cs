namespace _04._Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> vehicles = new();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] datas = Console.ReadLine().Split();
                Engine engine = new Engine(datas[1], int.Parse(datas[2]));
                Cargo cargo = new Cargo(int.Parse(datas[3]), datas[4]);
                vehicles.Add(new Car(datas[0], engine, cargo));
            }
            string input = Console.ReadLine();
            switch (input)
            {
                case "fragile":
                    foreach(Car car in vehicles.Where(x => x.CargoInfo.Type == input)
                        .Where(x => x.CargoInfo.Weight < 1000))
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
                case "flamable":
                    foreach (Car car in vehicles.Where(x => x.CargoInfo.Type == input)
                        .Where(x => x.EngineInfo.Power > 250))
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
            }
        }
    }
    public class Car
    {
        public string Model;
        public Engine EngineInfo;
        public Cargo CargoInfo;
         public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            EngineInfo = engine;
            CargoInfo = cargo;
        }
    }
    public class Engine
    {
        public string Speed;
        public int Power;
        public Engine(string speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }
    public class Cargo
    {
        public int Weight;
        public string Type;
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }

}
