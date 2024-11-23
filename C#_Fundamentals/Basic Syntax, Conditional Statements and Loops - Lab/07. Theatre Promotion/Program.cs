string dayType = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
string price = "";
if (0 <= age && age <= 18)
{
    if (dayType == "Weekday") price = "12$";
    else if (dayType == "Weekend") price = "15$";
    else if (dayType == "Holiday") price = "5$";
}
else if (18 < age && age <= 64)
{
    if (dayType == "Weekday") price = "18$";
    else if (dayType == "Weekend") price = "20$";
    else if (dayType == "Holiday") price = "12$";
}
else if (64 < age && age <= 122)
{
    if (dayType == "Weekday") price = "12$";
    else if (dayType == "Weekend") price = "15$";
    else if (dayType == "Holiday") price = "10$";
}
else price = "Error!";
Console.WriteLine(price);