using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class SoftUniLinkedList
    {
        private int count;

        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get => this.count; }

        public void AddHead(Node node)
        {
            count++;

            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Head.PreviousNode = node;
            node.NextNode = Head;
            Head = node;
        }

        public void AddTail(Node node)
        {
            count++;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Tail.NextNode = node;
            node.PreviousNode = Tail;
            Tail = node;
        }

        public Node RemoveHead()
        {
            Node oldHead = Head;

            if (Head == null)
            {
                return null;
            }

            count--;

            if (Head.NextNode != null)
            {
                Head = Head.NextNode;
                Head.PreviousNode = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }

            return oldHead;
        }

        public Node RemoveTail()
        {
            Node oldTail = Tail;

            if (Tail == null)
            {
                return null;
            }

            count--;

            if (Tail.PreviousNode == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.PreviousNode;
                Tail.NextNode = null;
            }

            return oldTail;
        }

        public void ForEachFromHead(Action<Node> action)
        {
            Node current = Head;

            while (current != null)
            {
                action(current);
                current = current.NextNode;
            }
        }

        public void ForEachFromTail(Action<Node> action)
        {
            Node current = Tail;

            while (current != null)
            {
                action(current);
                current = current.PreviousNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[count];

            int index = 0;

            ForEachFromHead(e => { array[index] = e.Value; index++; });

            return array;
        }
    }
}
