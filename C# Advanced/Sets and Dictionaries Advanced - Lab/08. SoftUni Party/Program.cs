namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> idSet = new();
            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                idSet.Add(input);
            }

            while ((input = Console.ReadLine()) != "END")
            {
                idSet.Remove(input);
            }
            Console.WriteLine(idSet.Count);
            foreach (var id in idSet.Where(id => char.IsDigit(id[0])))
            {
                Console.WriteLine(id);
            }
            foreach (var id in idSet.Where(id => char.IsLetter(id[0])))
            {
                Console.WriteLine(id);
            }

        }
    }
}
