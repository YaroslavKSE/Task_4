using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task_4;

// ------ Structure ------
var elementsFrequency = new Dictionary<char, int>();
var frequencyQueue = new PriorityQueue<Node, int>();
var elementsCode = new Dictionary<string, string>();
var codedFile = new List<string>();
var decodedList = new List<string>();


TextReader(elementsFrequency, @"dictionary.txt");

SortToQueue();

TreeBuilder();

var rootNode = frequencyQueue.Peek();
Encode(rootNode, "", elementsCode);

PrintCodedElements(elementsCode);

HuffmanCode(elementsFrequency);

PrintHuffmanCodedFile();

WriteHuffmanCodedFile();

DecodeTest();

// ------ Implementation ------
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

void PrintCodedElements(Dictionary<string, string> elements)
{
    foreach (var element in elements)
    {
        Console.Write(element.Key);
        Console.Write(":");
        Console.WriteLine(element.Value);
    }
}

void TextReader(Dictionary<char, int> storeElements,  string path)
{
    foreach (var line in File.ReadAllLines(path))
    {
        var elements = line.ToCharArray();
        foreach (var variable in elements)
        {
            if (storeElements.ContainsKey(variable))
            {
                storeElements[variable] += 1;
            }
            else
            {
                storeElements.Add(variable, 1);
            }
        }
    }
}

void SortToQueue()
{
    foreach (var VARIABLE in elementsFrequency)
    {
        frequencyQueue.Enqueue(new Node(VARIABLE.Key.ToString(), VARIABLE.Value, null, null), VARIABLE.Value);
    }
}

void TreeBuilder()
{
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
}

void HuffmanCode(Dictionary<char, int> elementFrequency)
{
    foreach (var element in elementFrequency)
    {
        var value = element.Value;
        while (value != 0)
        {
            value -= 1;
            codedFile.Add(elementsCode[element.Key.ToString()]);
        }
    }
}

void WriteHuffmanCodedFile()
{
    using StreamWriter writer = new StreamWriter("CodedFile.txt");
    foreach (var element in codedFile)
    {
        writer.Write(element);
    }
}

void PrintHuffmanCodedFile()
{
    foreach (var element in codedFile)
    {
        Console.Write(element);
    }
}

Node GetRightNode(Node parentNode)
{
    return parentNode.Right;
}

Node GetLeftNode(Node parentNode)
{
    return parentNode.Left;
}


void DecodeTest()
{
    foreach (var bit in codedFile)
    {
        var decoded = elementsCode.FirstOrDefault(x => x.Value == bit).Key;
        decodedList.Add(decoded);
    }
}

foreach (var VARIABLE in decodedList)
{
    Console.Write(VARIABLE);
}


// void DecodeFile()
// {
//     var decodedList = new List<string>();
//     if (rootNode == null)
//     {
//         return;
//     }
//     foreach (var bit in codedFile)
//     {
//         if (bit == "1")
//         {
//             if (IsLeaf(GetRightNode(rootNode)))
//             {
//                 decodedList.Add(GetRightNode(rootNode).Value);
//             }
//         }
//
//         if (bit == "0")
//         {
//             if (IsLeaf(GetLeftNode(rootNode)))
//             {
//                 decodedList.Add(GetLeftNode(rootNode).Value);
//             }    
//         }
//     }
// }

// DecodeFile();
