namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesStudents = new();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] infos = input.Split(" : ");
                string course = infos[0];
                string student = infos[1];

                if (!coursesStudents.ContainsKey(course))
                {
                    coursesStudents[course] = new List<string>();
                }
                coursesStudents[course].Add(student);

            }

            foreach ((string course, List<string> students) in coursesStudents)
            {
                Console.WriteLine($"{course}: {students.Count}");
                //Console.WriteLine(String.Join("--" + Environment.NewLine, students));
                foreach (string student in students)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
