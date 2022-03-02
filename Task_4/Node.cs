namespace Task_4
{
    public class Node
    {
        public string Value { get; }
        public int Frequency { get; }
        public readonly Node Left;
        public readonly Node Right;

        public Node(string value, int frequency, Node left, Node right)
        {
            Value = value;
            Frequency = frequency;
            Left = left;
            Right = right;

        }
    }
}
