namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(tokens.Reverse());
            int result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                switch(stack.Pop())
                {
                    case "+":
                        result += int.Parse(stack.Pop());
                        break;
                    case "-":
                        result -= int.Parse(stack.Pop());
                        break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
