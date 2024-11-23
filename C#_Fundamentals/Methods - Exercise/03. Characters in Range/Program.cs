namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void CharsBetween(char start, char end)
        {

            for (int i = start + 1; i < end; i++)
            {

                Console.Write((char)i + " ");
            }
        }
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            if (start > end)
            {
                CharsBetween(end, start);
            }
            else
            { 
                CharsBetween(start, end);
            }
        }
    }
}
