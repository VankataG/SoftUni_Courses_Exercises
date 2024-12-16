namespace _11._TriFunction
{
    internal class TriFunc
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();


            Func<string, int> findSumFunc = name => name.Sum(x => (int)x);

            string result = FindName(names, n, findSumFunc);
            Console.WriteLine(result);
        }

        static string FindName(List<string> names, int n, Func<string, int> findSumFunc)
        {
            foreach (var name in names)
            {

                if (findSumFunc(name) >= n)
                    return name;
            }
            return String.Empty;
        }
    }
}
