namespace _01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine()) * 1000;
            double hay = double.Parse(Console.ReadLine()) * 1000;
            double cover = double.Parse(Console.ReadLine()) * 1000;
            double weight = double.Parse(Console.ReadLine()) * 1000;

            bool goToStore = false;
            for (int day = 1; day <= 30; day++)
            {
                food -= 300;
                if (food <= 0)
                {
                    goToStore = true;
                    break;
                }
                if (day % 2 == 0)
                {
                    hay -= food * 0.05;
                    if (hay <= 0)
                    {
                        goToStore = true;
                        break;
                    }
                }
                 if (day % 3 == 0)
                {
                    cover -= weight / 3;
                    if (cover <= 0)
                    {
                        goToStore = true;
                        break;
                    }
                }
            }
            if (goToStore)
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
            else
            {
                food /= 1000;
                hay /= 1000;
                cover /= 1000;
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
        }
    }
}
