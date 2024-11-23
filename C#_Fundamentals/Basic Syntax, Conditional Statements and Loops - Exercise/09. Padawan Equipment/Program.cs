using System.Reflection.PortableExecutable;

double budget = double.Parse(Console.ReadLine());
int students = int.Parse(Console.ReadLine());
double lightsaberPrice = double.Parse(Console.ReadLine());
double robePrice = double.Parse(Console.ReadLine());
double beltPrice = double.Parse(Console.ReadLine());
 
double totalPrice = (lightsaberPrice * Math.Ceiling(students * 1.1)) + (robePrice * students) + (beltPrice * (students - (students/6)));

if (budget >= totalPrice)
{
    Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
}
else
{
    Console.WriteLine($"John will need {totalPrice - budget:f2}lv more.");
}