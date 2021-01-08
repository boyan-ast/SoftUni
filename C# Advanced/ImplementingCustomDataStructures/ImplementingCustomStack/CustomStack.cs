using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingCustomStack
{
    class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;

        public CustomStack()
        {
            this.items = new int[InitialCapacity]; 
        }

        public int Count { get; private set; }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        public void Push(int element)
        {
            if (Count == this.items.Length)
            {
                this.Resize();
            }

            for (int i = Count; i > 0; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[0] = element;

            this.Count++;
        }

        public int Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            int firstElement = this.items[0];

            for (int i = 0; i < Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[Count - 1] = default(int);

            this.Count--;

            if (Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return firstElement;
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return this.items[0];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
