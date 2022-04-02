using System;

namespace Task_4
{
    public class Heap
    {
        private static int _capacity = 10;
        private int _heapSize;
        private Node[] _elements = new Node[_capacity];

        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChild(int parentIndex)
        {
            return _elements[GetLeftChildIndex(parentIndex)].Frequency;
        }

        private int GetRightChild(int parentIndex)
        {
            return _elements[GetRightChildIndex(parentIndex)].Frequency;
        }

        private int GetParent(int childIndex)
        {
            return _elements[GetParentIndex(childIndex)].Frequency;
        }

        private bool HasLeftChild(int parentIndex)
        {
            return GetLeftChildIndex(parentIndex) < _heapSize;
        }
        
        private bool HasRightChild(int parentIndex)
        {
            return GetRightChildIndex(parentIndex) < _heapSize;
        }

        private bool HasParent(int childIndex)
        {
            return GetParentIndex(childIndex) >= 0;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var first = _elements[firstIndex];
            var second = _elements[secondIndex];
            _elements[firstIndex] = second;
            _elements[secondIndex] = first;
        }

        private void IncreaseSize()
        {
            if (_capacity == _heapSize)
            {
                var newSize = _capacity * 2;

                var biggerArray = new Node[newSize];
                for (int i = 0; i < _elements.Length; i++)
                {
                    biggerArray[i] = _elements[i];
                }
                _elements = biggerArray;
            }
        }

        public void Add(Node item)
        {
            IncreaseSize();
            _elements[_heapSize] = item;
            _heapSize++; 
            HeapifyUp();
        }

        private void HeapifyUp()
        {
            var childIndex = _heapSize - 1;
            while (HasParent(childIndex) && GetParent(childIndex) > _elements[childIndex].Frequency)
            {
                Swap(GetParentIndex(childIndex), childIndex);
                childIndex = GetParentIndex(childIndex);
            }
        }

        public Node GetMin()
        {
            if (_heapSize > 0) return _elements[0];
            throw new Exception("The heap is empty");
        }

        public Node PollTopItem()
        {
            var topNode = _elements[0];
            _elements[0] = _elements[_heapSize - 1];
            _heapSize--;
            HeapifyDown();
            return topNode;
        }

        private void HeapifyDown()
        {
            var elementIndex = 0;
            while (HasLeftChild(elementIndex))
            {
                var smallerChildIndex = GetLeftChildIndex(elementIndex);
                if (HasRightChild(elementIndex) && GetRightChild(elementIndex) < GetLeftChild(elementIndex))
                {
                    smallerChildIndex = GetRightChildIndex(elementIndex);
                }

                if (_elements[elementIndex].Frequency < _elements[smallerChildIndex].Frequency)
                {
                    break;
                }
                
                Swap(elementIndex, smallerChildIndex);

                elementIndex = smallerChildIndex;

            }
        }

        public int Count()
        {
            return _heapSize;
        }
    }
}
