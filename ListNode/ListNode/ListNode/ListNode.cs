namespace ListNode;

public class ListNode<T>
{
    public readonly T Value;
    public readonly ListNode<T>? Next;
    public ListNode(T value, ListNode<T>? next = null)
    {
        Value = value;
        Next = next;
    }
}

