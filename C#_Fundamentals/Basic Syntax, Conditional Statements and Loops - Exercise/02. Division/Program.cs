int n = int.Parse(Console.ReadLine());
int number = 0;
if (n % 10 == 0) number = 10;
else if (n % 7 == 0) number = 7;
else if (n % 6 == 0) number = 6;
else if (n % 3 == 0) number = 3;
else if (n % 2 == 0) number = 2;

if (number != 0) Console.WriteLine($"The number is divisible by {number}");
else Console.WriteLine("Not divisible");