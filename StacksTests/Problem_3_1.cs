using System;
using NUnit.Framework;
using DataStructures;
using DataStructures.Exceptions;

namespace StacksAndQueues
{
    /// <summary>
    /// Simulateing a stack with arrays is pretty stratigh forward
    /// the stack has the position index and points to the last added element
    ///  - when you add an element you frist moove the pointer then add the element
    ///  - when you remove the element you simply decrease the pointer
    ///  
    /// you create a stack class that contains the starting position and the ending position
    /// so you can manage the over/under flow and make stacks of different sizes
    /// 
    /// 
    /// </summary>
    public class ThreeStacksFormArray<T>
    {
        internal T[] array;
        InternalStack Stack1 { get; }
        InternalStack Stack2 { get; }
        InternalStack Stack3 { get; }
        public ThreeStacksFormArray(int size)
        {
            array = new T[size];
            Stack1 = new InternalStack(0, size / 3 - 1, array);
            Stack2 = new InternalStack(size / 3, size / 6 - 1, array);
            Stack3 = new InternalStack(size / 6, size - 1, array);

        }
        public class InternalStack
        {
            int startIndex, stopIndex, pointer;
            T[] array;
            public InternalStack(int start, int stop, T[] array)
            {
                startIndex = start;
                stopIndex = stop;
                this.array = array;
            }
            public void Add(T item)
            {
                if (IsOverflow())
                {
                    throw new StackOverflowException();
                }
                array[++pointer] = item;
            }

            private bool IsOverflow()
            {
                var currentPosition = startIndex + pointer;
                return currentPosition + 1 > stopIndex;
            }

            public T Remove()
            {
                if(pointer == 0)
                {
                    throw new StackEmptyException();
                }
                return array[pointer--];
            }
        }
    }
}
