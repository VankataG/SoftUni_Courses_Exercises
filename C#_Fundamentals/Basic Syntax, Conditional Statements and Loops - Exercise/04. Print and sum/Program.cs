int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int sum = 0;
for (int i = a; i <= b ; i++)
{
    sum += i;
    Console.Write($"{i} ");
}
Console.WriteLine();
Console.WriteLine($"Sum: {sum}");