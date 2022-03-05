using System;
using System.Collections.Generic;
using System.IO;
using Task_4;

// ------ GlobalVariables ------

var elementsFrequency = new Dictionary<char, int>();
var frequencyQueue = new PriorityQueue<Node, int>();
var elementsCode = new Dictionary<string, string>();
var codedFile = new List<string>();
var text = "";
var decodedFile = "";

// ------ Structure ------

FrequencyReader(elementsFrequency, @"dictionary.txt");

TextReader(@"dictionary.txt");

SortToQueue();

TreeBuilder();

var rootNode = frequencyQueue.Peek();
Encode(rootNode, "", elementsCode);

PrintCodedElements(elementsCode);

ConvertToHuffmanCode(text);

PrintHuffmanCodedFile();

WriteHuffmanCodedFile();

DecodeFile(rootNode, codedFile);

Console.WriteLine();
Console.WriteLine(decodedFile);


// ------ Implementation ------

void FrequencyReader(Dictionary<char, int> storeElements,  string path)
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

void TextReader(string path)
{
    foreach (var line in File.ReadLines(path))
    {
        text += line;
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
        
        var newNode = new Node(first.Value + second.Value, first.Frequency + second.Frequency, first, second);
        frequencyQueue.Enqueue(newNode, first.Frequency + second.Frequency);
        
    }
}

void Encode(Node root, string str, Dictionary<string, string> huffmanCode)
{
    if (root == null)
    {
        return;
    }

    if (IsLeaf(root))
    {
        huffmanCode.Add(root.Value, str);
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

void ConvertToHuffmanCode(string words)
{
    foreach (var letter in words)
    {
        codedFile.Add(elementsCode[letter.ToString()]);
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

void DecodeFile(Node root, List<string>codedText)
{
    var current = root;
    var word = string.Join("", codedText);

    foreach (var bit in word)
    {
        if (bit == '0')
        {
            current = current.Left;
        }
        else
        {
            current = current.Right;
        }

        if (current.Right == null && current.Left == null)
        {
            decodedFile += current.Value;
            current = root;
        }
    }
}
