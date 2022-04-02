using System.IO;

namespace Task_4;

public class TextReader
{
    public string Read(string text, string path)
    {
        foreach (var line in File.ReadLines(path))
        {
            text += line;
        }
        return text;
    }
}