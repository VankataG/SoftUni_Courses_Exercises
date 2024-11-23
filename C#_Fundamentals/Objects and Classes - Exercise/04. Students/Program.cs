namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] datas = Console.ReadLine().Split();
                Student student = new Student(datas[0], datas[1], double.Parse(datas[2]));
                students.Add(student);
            }
            students.Sort((x, y) => y.Grade.CompareTo(x.Grade));

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
    public class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }

    }
}
