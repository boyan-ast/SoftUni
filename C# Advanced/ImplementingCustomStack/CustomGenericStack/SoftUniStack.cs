using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomGenericStack
{
    public class SoftUniStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public SoftUniStack()
        {
            this.Count = 0;
            this.items = new T[InitialCapacity];
        }

        public int Count
        {
            get;
            private set;
        }

        public void Push(T element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T element = this.items[this.Count - 1];
            this.Count--;
            this.items[this.Count] = default(T);

            if (this.items.Length >= 4 && this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return element;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return this.items[this.Count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        private void Shrink()
        {
            T[] copy = new T[this.items.Length / 2];
            Array.Copy(this.items, copy, Count);
            this.items = copy;
        }

        private void Resize()
        {
            T[] copy = new T[this.items.Length * 2];

            Array.Copy(this.items, copy, Count);

            this.items = copy;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
