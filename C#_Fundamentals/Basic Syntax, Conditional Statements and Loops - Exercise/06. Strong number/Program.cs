string n = Console.ReadLine();
int number = int.Parse(n);
int copyN = number;
int sum = 0;
for (int i = 0; i < n.Length; i++)
{
    
    int digit = number % 10;
    copyN /= 10;

    int curSum = 1;
    for (int j = 1; j <= digit; j++)
    {
        curSum *= j;
    }
    sum += curSum;
}
if  (sum == number)
{
    Console.WriteLine("yes");
}
else
{
    Console.WriteLine("no");
}
