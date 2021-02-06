using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T> : IComparable<Box<T>>
        where T : IComparable<T>
    {
        private T item;
        public Box(T item)
        {
            this.item = item;
        }

        public int CompareTo(Box<T> other)
        {
            return item.CompareTo(other.item);
        }

        public override string ToString()
        {
            return $"{typeof(T).FullName}: {item}";
        }
    }
}
