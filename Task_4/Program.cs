using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task_4;

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


var frequencyQueue = new PriorityQueue<Node, int>();

foreach (var VARIABLE in elementsFrequency)
{
    frequencyQueue.Enqueue(new Node(VARIABLE.Key.ToString(), VARIABLE.Value, null, null), VARIABLE.Value);    
}

var HuffmanTree = new PriorityQueue<Node, int>();


while (frequencyQueue.Count > 1)
{
    var first = frequencyQueue.Dequeue();
    var second = frequencyQueue.Dequeue();
    if (first.Frequency <= second.Frequency)
        {
            var newNode = new Node(first.Value + second.Value, first.Frequency + second.Frequency, first, second);
            frequencyQueue.Enqueue(newNode, first.Frequency + second.Frequency);
        }
}

Console.WriteLine();