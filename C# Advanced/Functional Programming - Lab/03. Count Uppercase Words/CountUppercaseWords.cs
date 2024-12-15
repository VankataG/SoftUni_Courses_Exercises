namespace _03._Count_Uppercase_Words
{
    internal class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            
            Func<string,bool> IsUpperCaseWord = x => char.IsUpper(x[0]);
            foreach (string word in words)
            {
                if (IsUpperCaseWord(word))
                {
                    Console.WriteLine(word);
                }
            }

            //Another way

            //foreach (string word in words)
            //{
            //    if (Char.IsUpper(word[0]))
            //    {
            //        Console.WriteLine(word);
            //    }
            //}
        }
    }
}
