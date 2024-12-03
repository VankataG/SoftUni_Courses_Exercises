namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightTime = int.Parse(Console.ReadLine());
            int greenLight = greenLightTime;
            int freeWindowTime = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new();
            int carsPassed = 0;
            bool crashed = false;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green") // Indicates green light cycle
                {
                    while (greenLightTime > 0 && carsQueue.Count > 0)
                    {
                        string currCar = carsQueue.Dequeue();

                        if (currCar.Length <= greenLightTime)
                        {
                            greenLightTime -= currCar.Length;
                            carsPassed++;
                        }
                        else
                        {
                            int needed = currCar.Length - greenLightTime;
                            greenLightTime = 0;
                            if (needed <= freeWindowTime)
                            {
                                carsPassed++;

                            }
                            else
                            {
                                int index = currCar.Length - (needed - freeWindowTime);
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currCar} was hit at {currCar[index]}.");

                                crashed = true;
                            }
                        }
                    }

                    greenLightTime = greenLight;
                    if (crashed) break;
                }
                else // Add car to Queue
                {
                    carsQueue.Enqueue(input);
                }
            }

            if (!crashed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
        }
    }
}
