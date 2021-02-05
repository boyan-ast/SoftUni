using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingCustomList
{
    public class SoftUniList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public SoftUniList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public void Add(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            ValidateIndex(index);

            int removedElement = this.items[index];

            this.items[index] = default(int);
            this.ShiftLeft(index);

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }
            
            return removedElement;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void InsertAt(int index, int element)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
            else if (index == this.Count)
            {
                this.Add(element);
            }
            else
            {
                if (this.Count == this.items.Length)
                {
                    this.Resize();
                }

                this.ShiftRight(index);

                this.items[index] = element;
            }            
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.Count++;
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default(int);

            this.Count--;
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            Array.Copy(this.items, copy, Count);

            this.items = copy;
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
        }
    }
}
