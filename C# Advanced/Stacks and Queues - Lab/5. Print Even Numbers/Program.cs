namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> evenNums = new();
            Queue<int> numbersQ = new Queue<int>();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int  number in numbers)
            {
                numbersQ.Enqueue(number);
            }

            while (numbersQ.Count > 0)
            {
                int num = numbersQ.Dequeue();
                if (num % 2 == 0)
                    evenNums.Add(num);
            }
            
            Console.WriteLine(String.Join(", ", evenNums));

        }
    }
}
