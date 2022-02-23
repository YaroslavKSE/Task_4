namespace Task_4
{
    public class Node
    {
        public string Value { get; set; }
        public int Frequency { get; set; }
        public Node Left = null;
        public Node Right = null;

        public Node(string value, int frequency, Node left, Node right)
        {
            Value = value;
            Frequency = frequency;
            Left = left;
            Right = right;

        }
    }
}