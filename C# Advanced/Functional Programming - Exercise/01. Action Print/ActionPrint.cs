namespace _01._Action_Print
{
    internal class ActionPrint
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<string> printNameAction = PrintName;

            foreach (var name in names)
            {
                printNameAction(name);
            }
        }

         static void PrintName(string name)
        {
            Console.WriteLine("Sir " + name);
        }
    }
}
