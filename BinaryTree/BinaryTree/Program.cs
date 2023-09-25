using System;

namespace BinaryTree 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>(30);
            tree.Add(35);
            tree.Add(53);
            tree.Add(21);
            tree.Add(66);
            tree.Add(48);
            tree.Add(22);
            tree.Add(70);
            tree.Add(9);
            tree.Add(92);
            tree.Add(13);
            
            Console.WriteLine("Preorder обход : ");
            tree.PreOrder();
            
            Console.WriteLine();
            
            Console.WriteLine("\nBFS обход : ");
            tree.BFS();
          
        }
    }
}