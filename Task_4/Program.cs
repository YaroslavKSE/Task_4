using Task_4;
using TextReader = Task_4.TextReader;

var frequencyReader = new FrequencyReader();
var elementsFrequency = frequencyReader.Read(new Dictionary<char, int>(), "dictionary.txt");

var frequencyQueue = new PriorityQueue<Node, int>();
SortToQueue();

var textReader = new TextReader();
var text = textReader.Read("", @"dictionary.txt");

var builder = new TreeBuilder();
frequencyQueue = builder.Builder(frequencyQueue);

var huffmanTable = new Dictionary<string, string>();
var encoder = new TreeEncoder();
encoder.Encode(frequencyQueue.Peek(), "", huffmanTable);
encoder.PrintCodedElements(huffmanTable);

var codedFile = new List<string>();

ConvertToHuffmanCode(text);

var decoder = new Decoder();

var file = decoder.DecodeFile(frequencyQueue.Peek(), codedFile);

PrintHuffmanCodedFile();


WriteHuffmanCodedFile();

Console.WriteLine();
Console.WriteLine(file);

void SortToQueue()
{
    foreach (var VARIABLE in elementsFrequency)
    {
        frequencyQueue.Enqueue(new Node(VARIABLE.Key.ToString(), VARIABLE.Value, null, null), VARIABLE.Value);
    }
}

void ConvertToHuffmanCode(string words)
{
    foreach (var letter in words)
    {
        codedFile.Add(huffmanTable[letter.ToString()]);
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
    using StreamWriter writer = new StreamWriter("CodedFile.txt");
    foreach (var element in codedFile)
    {
        writer.Write(element);
    }
}
