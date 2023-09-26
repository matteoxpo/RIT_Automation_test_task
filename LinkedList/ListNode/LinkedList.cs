using System;
using System.Collections;
using System.Collections.Generic;

namespace ListNode;

public class LinkedList<T>  : IEnumerable<T> where T: IComparable<T>
{
    private ListNode<T>? _head;

    public void Add(T? value)
    {
        if (value is null)
        {
            throw new ArgumentNullException();
        }

        if (_head is null)
        {
            _head = new ListNode<T>(value);
        }
        else
        {
            _head = new ListNode<T>(value, _head);
        }
    }
    public IEnumerator<T> GetEnumerator()
    {
        var runner = _head;
        while (runner is not null)
        {
            yield return runner.Value;
            runner = runner.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public static LinkedList<T> Replace(LinkedList<T> list, T oldValue, T newValue)
    {
        var res = new LinkedList<T>();
        var revertedRes = new LinkedList<T>();

        foreach (var value in list)
        {
            if (value.CompareTo(oldValue) == 0)
            {
                revertedRes.Add(newValue);
            }
            else
            {
                revertedRes.Add(value);
            }
        }

        foreach (var value in revertedRes)
        {
            res.Add(value);
        }
        return res;
    }
    public static LinkedList<T> Join(LinkedList<T> src1, LinkedList<T> src2)
    {
        var res = new LinkedList<T>();
        var revertedRes = new LinkedList<T>();
        foreach (var value in src1)
        {
            revertedRes.Add(value);
        }
        foreach (var value in src2)
        {
            revertedRes.Add(value);
        }

        foreach (var value in revertedRes)
        {
            res.Add(value);
        }
        return res;
    }
}