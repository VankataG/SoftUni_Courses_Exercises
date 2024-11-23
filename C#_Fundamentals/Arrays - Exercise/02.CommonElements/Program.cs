namespace _02.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(' ').ToArray();
            string[] array2 = Console.ReadLine().Split(' ').ToArray();
            
            for ( int i = 0; i < array1.Length; i++ )
            {
                for ( int j = 0; j < array2.Length; j++ )
                {
                    if ( array1[i] == array2[j])
                    {
                       Console.Write(array2[j] + " ");
                    }
                }
            }

        }
    }
}
