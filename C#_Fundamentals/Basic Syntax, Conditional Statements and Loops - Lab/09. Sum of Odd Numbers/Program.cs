int n = int.Parse(Console.ReadLine());
int sum = 0;
int odd = 1;
for (int i = 0; i < n; i++)
{
    Console.WriteLine(odd);
    sum += odd;
    odd += 2;
}
Console.WriteLine($"Sum: {sum}");