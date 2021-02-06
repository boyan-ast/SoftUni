using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.AddFirst(i);
            }

            int[] array = list.ToArray();

            Console.WriteLine(string.Join(" ", array));

            DoublyLinkedList<string> stringList = new DoublyLinkedList<string>();

            for (int i = 0; i < 10; i++)
            {
                stringList.AddFirst("My number is " + i);
            }

            string[] stringArray = stringList.ToArray();

            Console.WriteLine(string.Join(" ", stringArray));
        }
    }
}
