using NUnit.Framework;

using DataStructures.Exceptions;
using System;
using DataStructures;

namespace StacksAndQueues
{
    /// <summary>
    /// per implementare una coda con due stack devo riuscire a prendere il primo elemento 
    /// aggiunto allo stack
    /// per fare ciò ogni volta che faccio pop sposto tutti gli elementi dallo stack 1 allo stack
    /// coda. la cosa interessante è che posso ottimizzare per una lunga serie di letture e scritture
    /// spostando gli elementi da stack a coda quando faccio pop e l'operazione inversa 
    /// quando faccio push senza dover fare il doppio travaso ogni volta
    /// 
    /// Complessità 
    /// Spazio O(n)
    /// caso peggiore, sposto gli elementi da stack a queue ogni volta 
    /// se riempio uno stack con n elementi faccio n operazioni per riempire queue e (n-1) per riempire stack
    /// O(n+n-1) => O(n)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Queue<T>
    {
        DataStructures.Stack<T> stack, queue;
        public Queue()
        {
            stack = new DataStructures.Stack<T>();
            queue = new DataStructures.Stack<T>();
        }

        internal bool IsEmpty
        {
            get { return stack.IsEmpty() && queue.IsEmpty(); }
        }

        internal T Remove()
        {
            if (IsEmpty)
                throw new EmptyQueueException();
            if(ItemsInStack())
                Move(stack, queue);
            return queue.Pop();
        }

        internal T Peek()
        {
            if (IsEmpty)
                throw new EmptyQueueException();
            if (ItemsInStack())
                Move(stack, queue);
            return queue.Peek();
        }

        internal void Add(T item)
        {
            if (ItemsInQueue())
                Move(queue,stack);
            stack.Push(item);
        }

        private void Move(Stack<T> stack1, Stack<T> stack2)
        {
            while (!stack1.IsEmpty())
            {
                stack2.Push(stack1.Pop());
            }
        }

        private bool ItemsInQueue()
        {
            return !queue.IsEmpty() && stack.IsEmpty();
        }
        private bool ItemsInStack()
        {
            return queue.IsEmpty() && !stack.IsEmpty();
        }
    }
    [TestFixture]
    public class Problem_3_4Tests
    {
        [Test]
        public void EmptyQueueIsEmpty()
        {
            var sut = new Queue<Item>();
            Assert.That(sut.IsEmpty, Is.True);
        }

        [Test]
        public void EmptyIntQueueIsEmpty()
        {
            var sut = new Queue<int>();
            Assert.That(sut.IsEmpty, Is.True);
        }
        [Test]
        public void RemoveFromEmptyQueueThrows()
        {
            var sut = new Queue<Item>();
            Assert.Throws<EmptyQueueException>(() => sut.Remove());
        }

        [Test]
        public void PeekFromEmptyQueueThrows()
        {
            var sut = new Queue<Item>();
            Assert.Throws<EmptyQueueException>(() => sut.Peek());
        }

        [Test]
        public void CanAddItemToQueue()
        {
            var sut = new Queue<Item>();
            sut.Add(new Item());
            Assert.That(sut.IsEmpty, Is.False);
        }

        [Test]
        public void CanRemoveItem()
        {
            var sut = new Queue<Item>();
            sut.Add(new Item());
            Assert.That(sut.IsEmpty, Is.False);
            sut.Remove();
            Assert.That(sut.IsEmpty, Is.True);
        }

        [Test]
        public void RemoveReturnsAnItem()
        {
            var sut = new Queue<Item>();
            var item = new Item();
            sut.Add(item);
            var returned = sut.Remove();
            Assert.That(returned, Is.EqualTo(item));
            Assert.That(sut.IsEmpty, Is.True);
        }

        [Test]
        public void PeekReturnsFirstItemWithoutRemovingIt()
        {
            var sut = new Queue<Item>();
            var item = new Item();
            sut.Add(item);
            var returned = sut.Peek();
            Assert.That(returned, Is.EqualTo(item));
            Assert.That(sut.IsEmpty, Is.False);
        }

        [Test]
        public void AddOrderIsPreserved()
        {
            var sut = new Queue<Item>();
            var item1 = new Item();
            sut.Add(item1);
            var item2 = new Item();
            sut.Add(item2);
            var returned = sut.Peek();
            Assert.That(returned, Is.EqualTo(item1));
            Assert.That(sut.IsEmpty, Is.False);
        }

        [Test]
        public void AddOrderIsPreservedAndRemoveRemovesItemsInAddedOrder()
        {
            var sut = new Queue<Item>();
            var item1 = new Item();
            sut.Add(item1);
            var item2 = new Item();
            sut.Add(item2);
            var returned = sut.Remove();
            Assert.That(returned, Is.EqualTo(item1));
            returned = sut.Remove();
            Assert.That(returned, Is.EqualTo(item2));

        }

        [Test]
        public void AddOrderIsPreservedAndRemoveRemovesItemsInAddedOrder3()
        {
            var sut = new Queue<Item>();
            var item1 = new Item();
            sut.Add(item1);
            var item2 = new Item();
            sut.Add(item2);
            var item3 = new Item();
            sut.Add(item3);

            var returned = sut.Remove();
            Assert.That(returned, Is.EqualTo(item1));
            returned = sut.Remove();
            Assert.That(returned, Is.EqualTo(item2));
            returned = sut.Remove();
            Assert.That(returned, Is.EqualTo(item3));
        }
    }
}
