int age = int.Parse(Console.ReadLine());
string output = "";
if (age <= 2) output = "baby";
else if (age <= 13) output = "child";
else if (age <= 19) output = "teenager";
else if (age <= 65) output = "adult";
else if (age > 65) output = "elder";
Console.WriteLine(output);