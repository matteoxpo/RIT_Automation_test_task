using System;
using System.Collections.Generic;

namespace BinaryTree;

public class BinaryTree<T> where T: IComparable<T>
{
    public BinaryTree(T key)
    {
        Key = key;
    }
    public T Key { get; private set; }
    public BinaryTree<T>? Left { get; set; }
    public BinaryTree<T>? Right { get; set; }

    public void Add(T value)
    {
        var compareResult = Key.CompareTo(value);
        if (compareResult < 0)
        {
            if (Right is not null)
            {
                Right.Add(value);
            }
            else
            {
                Right = new BinaryTree<T>(value);
            }
        } else if (compareResult > 0)
        {
            if (Left is not null)
            {
                Left.Add(value);
            }
            else
            {
                Left = new BinaryTree<T>(value);
            }
        }
        else
        {
            throw new BinaryTreeException($"Element with key = {value} is already in tree");
        }
        
    }

    public  void PreOrder()
    {
        PreOrder(this);    
    }
    

    public static void PreOrder(BinaryTree<T>? root)
    {
        if (root is not null)
        {
            Console.Write($"{root.Key} ");
            PreOrder(root.Left);
            PreOrder(root.Right);
        }
    }

    public void BFS()
    {
        BFS(this);
    }

    public static void BFS(BinaryTree<T>? root)
    {
        if (root is null)
        {
            return;
        }
        
        var queue = new Queue<BinaryTree<T>?>();
        queue.Enqueue(root);
            
        while (queue.Count != 0)
        {
            var current = queue.Dequeue();
            if (current is null)
            {
                continue;
            }
            queue.Enqueue(current.Left);
            queue.Enqueue(current.Right);
            Console.Write($"{current.Key} ");
        }
    }
    
}

public class BinaryTreeException : Exception
{
    public BinaryTreeException(string message) : base(message){}
}

