using System;
using System.Collections.Generic;

namespace Task_4
{
    public class Heap
    {
        private readonly List<int> _elements = new List<int>();
        public int RightChild(int element)
        {
            var index = _elements.IndexOf(element);
            return _elements[2 * index + 2];
        }

        public int LeftChild(int element)
        {
            var index = _elements.IndexOf(element);
            return _elements[2 * index + 1];
        }

        public int Parent(int element)
        {
            if (_elements.IndexOf(element) == 0)
            {
                return 0;
            }
            else
            {
                var i = (_elements.IndexOf(element) - 1) / 2;
                return _elements[i];
            }
        }

        public void HeapifyUp(int elementToAdd)
        {
            _elements.Add(elementToAdd);
            int indexOfChild = _elements.IndexOf(elementToAdd);
            if (Parent(indexOfChild) > elementToAdd)
            {
                _elements[Parent(indexOfChild)] = elementToAdd;
                _elements[indexOfChild] = Parent(indexOfChild);
            }

            if (_elements.Count == 0)
            {
                _elements[0] = elementToAdd;
            }
        }
        
    }
    
}