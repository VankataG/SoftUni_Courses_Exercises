namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(", ");
                string carNum = info[1];
                switch (info[0])
                {
                    case "IN":
                        parkingLot.Add(carNum);
                        break;
                    case "OUT":
                        parkingLot.Remove(carNum);
                        break;
                }
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(String.Join("\n", parkingLot));
            }
        }
    }
}
