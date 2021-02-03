using System;

namespace CustomDoublyLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            SoftUniLinkedList list = new SoftUniLinkedList();

            for (int i = 0; i < 5; i++)
            {
                list.AddHead(new Node(i + 1));
            }

            for (int i = 6; i < 11; i++)
            {
                list.AddTail(new Node(i));
            }

            Node current = list.Head;

            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.NextNode;
            }

            int[] listToArray = list.ToArray();

            Console.WriteLine(string.Join(" ", listToArray));

            Console.WriteLine(list.RemoveHead().Value);
            Console.WriteLine(list.RemoveTail().Value);

            listToArray = list.ToArray();

            Console.WriteLine(string.Join(" ", listToArray));

            list.ForEachFromTail(x => Console.Write($"{x.Value} "));
            Console.WriteLine();
        }
    }
}
