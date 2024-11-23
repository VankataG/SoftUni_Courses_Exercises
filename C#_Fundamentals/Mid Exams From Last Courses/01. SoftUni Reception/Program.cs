namespace _01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int emp1Students = int.Parse(Console.ReadLine());
            int emp2Students = int.Parse(Console.ReadLine());
            int emp3Students = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            int hours = 0;

            int answeredPerHour = emp1Students + emp2Students + emp3Students;
            while (students > 0)
            {
                students -= answeredPerHour;
                hours++;
                if (hours % 4 == 0)
                {
                    hours++;
                }

            }
            Console.WriteLine($"Time needed: {hours}h.");

        }
    }
}
