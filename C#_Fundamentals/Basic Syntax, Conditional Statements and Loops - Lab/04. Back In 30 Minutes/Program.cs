int hour = int.Parse(Console.ReadLine());
int minutes = int.Parse(Console.ReadLine());

minutes += 30;
if (minutes >= 60)
{
    hour++;
    minutes -= 60;
    if (hour >= 24)
    {
        hour = 0;
    }
}
if (minutes < 10)
    Console.WriteLine($"{hour}:0{minutes}");
else
    Console.WriteLine($"{hour}:{minutes}");