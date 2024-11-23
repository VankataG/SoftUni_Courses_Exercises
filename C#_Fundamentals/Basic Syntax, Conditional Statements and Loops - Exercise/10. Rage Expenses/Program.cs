int lostGames = int.Parse(Console.ReadLine());
double headSetPrice = double.Parse(Console.ReadLine());
double mousePrice = double.Parse(Console.ReadLine());
double keyboardPrice = double.Parse(Console.ReadLine());
double displayPrice = double.Parse(Console.ReadLine());

int headSets = lostGames / 2;
int mouses = lostGames / 3;
int keyboards = lostGames / 6;
int displays = lostGames / 12;
double expenses = headSets * headSetPrice + mouses * mousePrice + keyboardPrice * keyboards + displayPrice * displays;
Console.WriteLine($"Rage expenses: {expenses:f2} lv.");