using System;
using System.Collections.Generic;
using System.IO;
using Task_4;

var elementsFrequency = new Dictionary<char, int>();

foreach (var line in File.ReadAllLines(@"dictionary.txt"))
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

var rootNode = frequencyQueue.Peek();
var Coded = new Dictionary<string, string>();
Encode(rootNode, "", Coded);
PrintCodedElements(Coded);

void Encode(Node root, string str, Dictionary<string, string> huffmanCode)
{
    if (root == null)
    {
        return;
    }

    if (isLeaf(root))
    {
        huffmanCode.Add(root.Value, str.Length > 0 ? str : "1");
    }
    Encode(root.Left, str + "0", huffmanCode);
    Encode(root.Right, str + "1", huffmanCode);
}

bool isLeaf(Node node)
{
    if (node.Left == null && node.Right == null)
    {
        return true;
    }

    return false;
}

Node GetChildRight(Node node)
{
    return node.Right;
}

Node GetChildLeft(Node node)
{
    return node.Left;
}

void PrintCodedElements(Dictionary<string, string> elements)
{
    foreach (var element in elements)
    {
        Console.Write(element.Key); Console.Write(":"); Console.WriteLine(element.Value);
    }
}
