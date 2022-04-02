using System;
using System.Collections.Generic;
using System.IO;
using Task_4;

// ------ GlobalVariables ------

var elementsFrequency = new Dictionary<char, int>();
var Heap = new Heap();
var elementsCode = new Dictionary<string, string>();
var codedFile = new List<string>();
var text = "";
var decodedFile = "";

// ------ Structure ------

FrequencyReader(elementsFrequency, @"C:\C#\ConsoleApp1\dictionary.txt");

TextReader(@"C:\C#\ConsoleApp1\dictionary.txt");

TreeBuilder();

var rootNode = Heap.GetMin();
Encode(rootNode, "", elementsCode);

PrintCodedElements(elementsCode);

ConvertToHuffmanCode(text);

PrintHuffmanCodedFile();

WriteHuffmanCodedFile();

DecodeFile(rootNode, codedFile);

Console.WriteLine();
Console.WriteLine(decodedFile);

void TreeBuilder()
{
    foreach (var keyValue in elementsFrequency)
    {
        Heap.Add(new Node(keyValue.Key.ToString(), keyValue.Value, null, null));
    }

    while (Heap.Count() != 1)
    {
        var first = Heap.PollTopItem();
        var second = Heap.PollTopItem();
        var toAdd = new Node(first.Value + second.Value, first.Frequency + second.Frequency, first, second);
        Heap.Add(toAdd);
    }
}

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

void PrintHuffmanCodedFile()
{
    foreach (var element in codedFile)
    {
        Console.Write(element);
    }
}

void WriteHuffmanCodedFile()
{
    using StreamWriter writer = new StreamWriter(@"C:\C#\ConsoleApp1\CodedFile.txt");
    foreach (var element in codedFile)
    {
        writer.Write(element);
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

