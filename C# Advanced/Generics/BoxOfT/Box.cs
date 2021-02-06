using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> items;

        public Box()
        {
            items = new Stack<T>();
        }

        public int Count 
        { 
            get
            {
                return items.Count;
            }
        }
        
        public void Add(T element)
        {
            items.Push(element);
        }

        public T Remove()
        {
            return items.Pop();
        }
    }
}
