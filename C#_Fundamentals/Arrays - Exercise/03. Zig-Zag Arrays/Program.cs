namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array1 = new int[n];
            int[] array2 = new int[n];
            int key = 0;

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    array1[key] = numbers[0];
                    array2[key] = numbers[1];
                }
                else
                {
                    array1[key] = numbers[1];
                    array2[key] = numbers[0];
                }
                key++;

            }
            
            Console.WriteLine(String.Join(" ", array1));
            Console.WriteLine(String.Join(" ", array2));



        }

    }
}
