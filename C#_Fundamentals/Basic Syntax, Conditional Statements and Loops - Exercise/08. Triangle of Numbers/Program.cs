﻿using System.Runtime.InteropServices;

int n = int.Parse(Console.ReadLine());

for (int rows = 1; rows <= n; rows++)
{
    for (int cols = 1; cols <= rows; cols++)
    {
        Console.Write($"{rows} ");
    }
    Console.WriteLine();
}
