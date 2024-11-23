namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            
            int sumAandB = SumAandB(a, b);
            int answer = SubtractCofSum(sumAandB, c);
            Console.WriteLine(answer);
        }
        static int SumAandB(int a, int b)
        {
            return a + b; 
        }
        static int SubtractCofSum(int sum,int c)
        {
            return sum - c;
        }
    }
}
