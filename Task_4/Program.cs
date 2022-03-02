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
var CodedFile = new List<string>();

Encode(rootNode, "", Coded);

PrintCodedElements(Coded);

HuffmanCode(elementsFrequency);

WriteHuffmanCodedFile();


foreach (var element in CodedFile)
{
    Console.Write(element);
}


void Encode(Node root, string str, Dictionary<string, string> huffmanCode)
{
    if (root == null)
    {
        return;
    }

    if (IsLeaf(root))
    {
        huffmanCode.Add(root.Value, str.Length > 0 ? str : "1");
    }
    Encode(root.Left, str + "0", huffmanCode);
    Encode(root.Right, str + "1", huffmanCode);
}

bool IsLeaf(Node node)
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


void HuffmanCode(Dictionary<char, int> elementFrequency)
{
    foreach (var element in elementFrequency)
    {
        var value = element.Value;
        while (value != 0 )
        {
            value -= 1;
            CodedFile.Add(Coded[element.Key.ToString()]);
        }
    }
}

void WriteHuffmanCodedFile()
{
    using StreamWriter writer = new StreamWriter("CodedFile.txt");
    foreach (var element in CodedFile)
    {
        writer.Write(element);
    }
}
