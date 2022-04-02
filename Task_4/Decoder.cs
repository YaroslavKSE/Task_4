using System.Collections.Generic;

namespace Task_4;

public class Decoder
{
    public string DecodeFile(Node root, List<string>codedText)
    {
        string decodedFile = null;
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

        return decodedFile;
    }
}