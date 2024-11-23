string input = Console.ReadLine();
double totalMoney = 0;
while (input != "Start")
{
    double money = double.Parse(input);
    if (money == 0.1 || money == 0.2 || money == 0.5 || money == 1 || money == 2) totalMoney += money;
    else
    {
        Console.WriteLine($"Cannot accept {money}");
    }
        input = Console.ReadLine();
    
}

    input = Console.ReadLine();

while (input != "End")
{
    double price = 0;
    if (input == "Nuts") { price = 2; input = "nuts"; }
    else if (input == "Water") { price = 0.7; input = "water"; }
    else if (input == "Crisps") { price = 1.5; input = "crisps"; }
    else if (input == "Soda") { price = 0.8; input = "soda";  }
    else if (input == "Coke") { price = 1; input = "coke"; }
    else
    {
        Console.WriteLine("Invalid product");
        input = Console.ReadLine();
        continue;
    }
    if (totalMoney >= price)
    {
        Console.WriteLine($"Purchased {input}");
        totalMoney -= price;
    }
    else if (totalMoney < price)
    {
        Console.WriteLine("Sorry, not enough money");
    }
    input = Console.ReadLine();
}
if (input == "End")
Console.WriteLine($"Change: {totalMoney:f2}");