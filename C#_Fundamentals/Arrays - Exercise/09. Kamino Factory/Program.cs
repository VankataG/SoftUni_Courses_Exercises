namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int seqLength = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int bestSeqIndex = 1;
            string[] bestSeq = Array.Empty<string>();
            int bestSeqSum = 0;
            int bestStartIndex = int.MaxValue;
            int bestCount = 0;

            int index = 0;
            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int sum = 0;
                index += 1;
                int count = 0;

                string[] sampleDna = input.Split("!", StringSplitOptions.RemoveEmptyEntries);

                if (bestSeq.Length == 0)
                {
                    bestSeq = sampleDna;
                }
                for (int i = seqLength - 1; i >= 0; i--)
                {
                    if (sampleDna[i] == "1")
                    {
                        count++;
                        sum++;
                        if (count > bestCount || bestStartIndex > i || bestSeqSum < sum)
                        {
                            bestSeq = sampleDna;
                            bestStartIndex = i;
                            bestSeqIndex = index;
                            bestCount = count;
                            bestSeqSum = sum;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            Console.WriteLine($"Best DNA sample {bestSeqIndex} with sum: {bestSeqSum}.");
            Console.WriteLine(String.Join(' ', bestSeq));
        }
    }
}
