int people = int.Parse(Console.ReadLine());
string type = Console.ReadLine();
string day = Console.ReadLine();
double price = 0;
double totalPrice = 0;
 if (type == "Students")
{
    if (day == "Friday") price = 8.45;
    else if (day == "Saturday") price = 9.80;
    else if (day == "Sunday") price = 10.46;
    totalPrice = people * price;
    if (people >= 30) totalPrice *= 0.85;
}
 else if (type == "Business")
{
    if (day == "Friday") price = 10.90;
    else if (day == "Saturday") price = 15.60;
    else if (day == "Sunday") price = 16;
    totalPrice = people * price;
    if (people >= 100) totalPrice -= 10 * price;

}
 else if (type == "Regular")
{
    if (day == "Friday") price = 15;
    else if (day == "Saturday") price = 20;
    else if (day == "Sunday") price = 22.50;
    totalPrice = people * price;
    if (people > 9 && people < 21) totalPrice *= 0.95;
}

Console.WriteLine($"Total price: {totalPrice:f2}");