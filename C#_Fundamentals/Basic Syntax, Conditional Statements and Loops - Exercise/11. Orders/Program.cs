int orders = int.Parse(Console.ReadLine());

double total = 0;
for (int i = 1 ; i <= orders; i++)
{
    double capsulePrice = double.Parse(Console.ReadLine());
    int days = int.Parse(Console.ReadLine());
    int capsules = int.Parse(Console.ReadLine());
    double price = (days * capsules) * capsulePrice;
    total += price;
    Console.WriteLine($"The price for the coffee is: ${price:f2}");
}
Console.WriteLine($"Total: ${total:f2}");