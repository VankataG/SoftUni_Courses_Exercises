namespace ClickBait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> engagementScores = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Stack<int> popularityScores = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int targetEngValue = int.Parse(Console.ReadLine());

            List<int> finalFeed = new();

            while (engagementScores.Count > 0 && popularityScores.Count > 0)
            {
                int queueElement = engagementScores.Dequeue();
                int stackElement = popularityScores.Pop();
                int remainder = default;

                if (queueElement > stackElement)
                {
                    remainder = queueElement % stackElement;
                    finalFeed.Add(remainder * -1);
                    if (remainder != 0)
                    {
                        engagementScores.Enqueue(remainder * 2);
                    }

                }
                else if (stackElement > queueElement)
                {
                    remainder = stackElement % queueElement;
                    finalFeed.Add(Math.Abs(remainder));
                    if (remainder != 0)
                    {
                        popularityScores.Push(remainder * 2);
                    }
                }
                else
                {
                    finalFeed.Add(0);
                }
            }

            Console.WriteLine("Final Feed: " + String.Join(", ", finalFeed));

            int totalEngValue = finalFeed.Sum();
            if (totalEngValue >= targetEngValue)
            {
                Console.WriteLine($"Goal achieved! Engagement Value: {totalEngValue}");
            }
            else
            {
                int shortFall = targetEngValue - totalEngValue;
                Console.WriteLine($"Goal not achieved! Short by: {shortFall}");
            }

        }
    }
}
