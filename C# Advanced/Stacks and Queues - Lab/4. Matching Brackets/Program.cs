
//1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5


namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a stack
            Stack<int> stack = new Stack<int>();

            //Read an expression
            string expression = Console.ReadLine();

            //Loop through it
            for (int i = 0; i < expression.Length; i++)
            {
                //Define a char
                char ch = expression[i];

                //Find the brackets in the expression
                if (ch == '(')
                {
                    stack.Push(i);
                }
                else if (ch == ')')
                {
                    //Define indexes and substring the output
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    string subExpr = expression.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(subExpr);
                }
            }
        }
    }
}
