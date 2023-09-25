using System;

namespace ListNode 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list1 = new LinkedList<int>();

            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(55);
            Console.WriteLine("List #1");
            PrintList(list1);
            
            var list2 = new LinkedList<int>();
            list2.Add(12);
            list2.Add(13);
            list2.Add(14);

            Console.WriteLine("List #2");
            PrintList(list2);

            Console.WriteLine();
            Console.WriteLine("Joined list #1 and list #2");
            PrintList(LinkedList<int>.Join(list1, list2));

            Console.WriteLine();
            Console.WriteLine("List #1");
            PrintList(list1);

            Console.WriteLine("Replace value 55 to 5");
            PrintList(LinkedList<int>.Replace(list1, 55, 5));


        }

        public static void PrintList<T>(LinkedList<T> list) where T: IComparable<T>
        {
            foreach (var node in list)
            {
                Console.Write($"{node} ");
            }
            Console.WriteLine();
        }
    }
}