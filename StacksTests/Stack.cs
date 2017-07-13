namespace StacksAndQueues
{
    /// <summary>
    /// LIFO
    /// No costant time to access i-th element like array
    /// constant time to add and remove
    /// usefull in recursive algorithms especially when you want to undo actions
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Stack<T>
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

        internal bool IsEmpty()
        {
            return top == null;
        }

        internal T Peek()
        {
            if (IsEmpty())
            {
                throw new StackEmptyException();
            }
            return top.Value;
        }

        internal T Pop()
        {
            if (IsEmpty())
            {
                throw new StackEmptyException();
            }
            var result = top;
            top = result.Next;
            return result.Value;
        }

        internal void Push(T item)
        {
            top = new StackNode(item, top);
        }
    }
}
