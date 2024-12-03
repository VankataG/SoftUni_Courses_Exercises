namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songsArr = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(songsArr);

            while (songs.Count > 0)
            {
                string input = Console.ReadLine();
                string[] commands = input.Split();
                switch (commands[0])
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        string song = input.Substring(4);
                        if (!songs.Contains(song))
                        {
                            songs.Enqueue(song);

                        }
                        else
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", songs));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
