using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddFirst(i);
            }

            int[] array = list.ToArray();
        }
    }
}
