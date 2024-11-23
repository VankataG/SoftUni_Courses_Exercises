using System.Security.Authentication;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments =command.Split();

                switch (arguments[0])
                {
                    case "exchange":
                        int index = int.Parse(arguments[1]);
                        numbers = Exchange(numbers, index);
                        break;

                    case "max":
                        string maxType = arguments[1];
                        PrintMax(numbers, maxType);
                        break;

                    case "min":
                        string minType = arguments[1];
                        PrintMin(numbers, minType);
                        break;

                    case "first":
                        int firstCount = int.Parse(arguments[1]);
                        string firstType = arguments[2];
                        PrintFirst(numbers, firstCount, firstType);
                        break;

                    case "last":
                        int lastCount = int.Parse(arguments[1]);
                        string lastType = arguments[2];
                        PrintLast(numbers, lastCount, lastType);
                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
        static int[] Exchange(int[] array, int index)
        {
            if ( index < 0 || index >= array.Length)
            {
                Console.WriteLine("Invalid index");
                return array;
            }
            else
            {
                int[] exchangedArray = new int[array.Length];
                int exchangedIndex = 0;
                for (int i = index + 1; i < array.Length; i++)
                {
                    exchangedArray[exchangedIndex++] = array[i];
                }
                for (int i = 0; i <= index; i++)
                {
                    exchangedArray[exchangedIndex++] = array[i];
                }

                return exchangedArray;
            }
        }
        static void PrintMax(int[] array, string type)
        {
            int maxIndex = -1;
            int maxValue = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (type == "even" &&  array[i] % 2 == 0 ||
                    type == "odd" && array[i] % 2 != 0)
                {
                    if (array[i] >= maxValue)
                    {
                        maxValue = array[i];
                        maxIndex = i;
                    }
                }
            }
            if (maxIndex != -1)
            {
                Console.WriteLine(maxIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
        static void PrintMin(int[] array, string type)
        {
            int minIndex = -1;
            int minValue = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (IsEvenOrOdd(array, type, i))
                {
                    if (array[i] <= minValue)
                    {
                        minValue = array[i];
                        minIndex = i;
                    }
                }
            }
            if (minIndex != -1)
            {
                Console.WriteLine(minIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static bool IsEvenOrOdd(int[] array, string type, int i)
        {
            return type == "even" && array[i] % 2 == 0 ||
                                type == "odd" && array[i] % 2 != 0;
        }

        static void PrintFirst(int[] array, int count, string type)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int currentCount = 0;
            string first = "";
            for (int i = 0; i < array.Length; i++)
            if (IsEvenOrOdd(array, type, i))
                {
                    first += $"{array[i]}, ";
                    currentCount++;
                    if (currentCount == count)
                    {
                        break;
                    }
                }
            Console.WriteLine($"[{first.Trim(',', ' ')}]");
        }
        static void PrintLast(int[] array, int count, string type)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int currentCount = 0;
            string last = "";
            for (int i = array.Length - 1; i >= 0; i--)
                if (IsEvenOrOdd(array, type, i))
                {
                    last = $"{array[i]}, " + last;
                    currentCount++;
                    if (currentCount == count)
                    {
                        break;
                    }
                }
            Console.WriteLine($"[{last.Trim(',', ' ')}]");
        }

    }
}
