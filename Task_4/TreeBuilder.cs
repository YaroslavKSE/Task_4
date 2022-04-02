using System.Collections.Generic;

namespace Task_4;

public class TreeBuilder
{
    public PriorityQueue<Node, int> Builder(PriorityQueue<Node, int> frequencyQueue)
    {
        while (frequencyQueue.Count > 1)
        {
            var first = frequencyQueue.Dequeue();
            var second = frequencyQueue.Dequeue();
        
            var newNode = new Node(first.Value + second.Value, first.Frequency + second.Frequency, first, second);
            frequencyQueue.Enqueue(newNode, first.Frequency + second.Frequency);
        }

        return frequencyQueue;
    }
}