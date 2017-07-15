using System;
using DataStructures.Exceptions;
namespace DataStructures
{
    /// <summary>
    /// FIFO
    ///  - breadth-first search 
    ///    - to store a list of the nodes that we need to process
    ///  - in implementing a cache
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
    {
        class QueueNode
        {
            public T Value { get; }
            public QueueNode Next { get; set; }
            public QueueNode(T front)
            {
                Value = front;
            }
        }
        private QueueNode front;
        private QueueNode last;
        public Queue()
        {
        }

        public bool IsEmpty
        {
            get
            {
                return front == null;
            }   
        }

        public T Remove()
        {
            if (IsEmpty)
            {
                throw new EmptyQueueException();
            }
            var value = front.Value;
            front = front.Next;
            return value;
        }

        public T Peek()
        {
            if (IsEmpty) {
                throw new EmptyQueueException();
            }
            return front.Value;
        }

        public void Add(T item)
        {
            if (IsEmpty)
            {
                front = new QueueNode(item);
                last = front;
            }
            else
            {
                last.Next = new QueueNode(item);
                last = last.Next;
            }

        }
    }
}