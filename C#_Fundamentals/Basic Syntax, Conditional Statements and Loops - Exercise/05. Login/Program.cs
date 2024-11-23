string user = Console.ReadLine();
string pass = "";
for (int i = user.Length-1; i >= 0; i--)
{
    pass +=user[i];
}
int wrong = 0;
string password = Console.ReadLine();
while (password != pass)
{
    wrong++;
    if (wrong == 4)
        break;
    Console.WriteLine("Incorrect password. Try again.");
    password = Console.ReadLine();
}
if (wrong == 4)
{
    Console.WriteLine($"User {user} blocked!");
}
else
{
    Console.WriteLine($"User {user} logged in.");
}