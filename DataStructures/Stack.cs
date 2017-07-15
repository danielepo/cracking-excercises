using DataStructures.Exceptions;
namespace DataStructures
{
    /// <summary>
    /// LIFO
    /// No costant time to access i-th element like array
    /// constant time to add and remove
    /// usefull in recursive algorithms especially when you want to undo actions
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T>
    {
        class StackNode
        {
            public StackNode(T value, StackNode next)
            {
                Value = value;
                Next = next;
            }
            public T Value { get; set; }
            public StackNode Next { get; set; }
        }
        StackNode top;
        public Stack()
        {
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new StackEmptyException();
            }
            return top.Value;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new StackEmptyException();
            }
            var result = top;
            top = result.Next;
            return result.Value;
        }

        public void Push(T item)
        {
            top = new StackNode(item, top);
        }
    }
}
