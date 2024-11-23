namespace _01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double students = double.Parse(Console.ReadLine());
            double lectures = double.Parse(Console.ReadLine());
            double bonus = double.Parse(Console.ReadLine());
            double maxBonus = default;
            double bestAttendances = default;
            for (int i = 1; i <= students; i++)
            {
                double attendances = int.Parse(Console.ReadLine());
                double studentBonus = attendances / lectures * (5 + bonus);
                if (studentBonus > maxBonus)
                {
                    maxBonus = studentBonus;
                    bestAttendances = attendances;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {bestAttendances} lectures.");
        }
    }
}
