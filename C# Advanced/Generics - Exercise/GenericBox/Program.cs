namespace GenericBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> list = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                list.Add(box);

            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index1 = indexes[0];
            int index2 = indexes[1];

            (list[index1].Value, list[index2].Value) = (list[index2].Value, list[index1].Value);

            foreach (var box in list)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
