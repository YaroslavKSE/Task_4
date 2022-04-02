using System;
using System.Collections.Generic;

namespace Task_4;

public class TreeEncoder
{
    public void Encode(Node rootNode, string code, Dictionary<string, string> huffmanTable)
    {
        if (rootNode == null)
        {
            return;
        }
    
        if (IsLeaf(rootNode))
        {
            huffmanTable.Add(rootNode.Value, code);
        }

        Encode(rootNode.Left, code + "0", huffmanTable);
        Encode(rootNode.Right, code + "1", huffmanTable);
    }
    public void PrintCodedElements(Dictionary<string, string> elements)
    {
        foreach (var element in elements)
        {
            Console.Write(element.Key);
            Console.Write(":");
            Console.WriteLine(element.Value);
        }
    }


    bool IsLeaf(Node node)
    {
        return node.Left == null && node.Right == null;
    }
}