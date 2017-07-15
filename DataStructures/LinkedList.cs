using System;

namespace DataStructures
{
    /// <summary>
    /// Represents a sequence of nodes
    /// Each points to the next one
    ///  - Singly linked lists points only forward
    ///  - Doubly linked lists points in both directions
    ///  
    /// No constant time access to an index
    ///  - you have to iterate through all the list to find an element
    ///  
    /// You can add an remove elements form the begining at constant time
    /// 
    /// The runner tecnique is when you use more that one pointers that move through the list at different speed
    /// you could sometimes use recurson but recursion takes at least O(n) space
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>
    {

        public class ListNode
        {
            public ListNode(T value)
            {
                Value = value;
            }
            public T Value { get; }
            public ListNode Next { get; set; }
        }
        ListNode head;
        ListNode tail;
        public LinkedList()
        {
        }

        public bool IsEmpty { get { return head == null; } }

        public void AppendToTail(T item)
        {
            if (IsEmpty)
            {
                head = new ListNode(item);
                tail = head;
            }
            else
            {
                tail.Next = new ListNode(item);
                tail = tail.Next;
            }

        }

        public ListNode Head
        {
            get { return head; }
        }

        public ListNode Delete(T item)
        {
            if (IsEmpty)
                return null;
            if (head.Value.Equals(item))
            {

                var oldHead = head;
                var newHead = head.Next;
                oldHead.Next = null;
                head = newHead;
                return oldHead;
            }
            ListNode current = head.Next;
            ListNode previous = head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    //remove
                    previous.Next = current.Next;
                    current.Next = null;
                    return current;
                }
                else
                {
                    current = current.Next;
                }
            }
            return null;
        }

        public ListNode Find(T item)
        {
            return FindFrom(item, head);
        }
        public ListNode FindFrom(T item, ListNode current)
        {
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
        public ListNode Find(T item, ListNode node)
        {
            return FindFrom(item, node.Next);
        }


        public ListNode Delete(T item, ListNode node)
        {
            ListNode current = node.Next;
            ListNode previous = node;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    //remove
                    previous.Next = current.Next;
                    current.Next = null;
                    return current;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
            return null;
        }
    }
}