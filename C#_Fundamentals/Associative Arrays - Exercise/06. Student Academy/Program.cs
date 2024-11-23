namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGrades = new();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<double>();
                }
                studentsGrades[name].Add(grade);
            }

            var filteredStudentsGrades = studentsGrades
                .Where(student => student.Value.Average() >= 4.50)
                .ToDictionary(student => student.Key, student => student.Value);
            
            foreach ((string student,  List<double> grades) in filteredStudentsGrades)
            {
                Console.WriteLine($"{student} -> {grades.Average():f2}");
            }
        }
    }
}
