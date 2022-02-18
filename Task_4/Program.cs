using System;
using System.Collections.Generic;
using System.IO;


var elementsFrequency = new Dictionary<char, int>();

foreach (var line in File.ReadAllLines(@"D:\C#\Task_4\Task_4\dictionary.txt"))
{
    var elements = line.ToCharArray();
    foreach (var variable in elements)
    {
        if (elementsFrequency.ContainsKey(variable))
        {
            elementsFrequency[variable] += 1;
        }
        else
        {
            elementsFrequency.Add(variable, 1);
        }
    }
}

Console.WriteLine();