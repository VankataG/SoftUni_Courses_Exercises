namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentsGradesMap = new();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ").ToArray();
                string name = command[0];
                decimal grade = decimal.Parse(command[1]);

                if (!studentsGradesMap.ContainsKey(name))
                {
                    studentsGradesMap.Add(name, new List<decimal>());
                }

                studentsGradesMap[name].Add(grade);
            }

            foreach ((string name, List<decimal> grades) in studentsGradesMap)
            {
                Console.WriteLine($"{name} -> {String.Join(" ", grades.Select(g => g.ToString("f2")))} (avg: {grades.Average():0.00})");
            }
        }
    }
}
