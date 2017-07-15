using System;
using NUnit.Framework;
using DataStructures;
using DataStructures.Exceptions;

namespace StacksAndQueues
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void EmptyStackIsEmpty()
        {
            var sut = new Stack<Item>();
            Assert.IsTrue(sut.IsEmpty());
        }

        [Test]
        public void CanPushItem()
        {
            var sut = new Stack<Item>();
            sut.Push(new Item());
            Assert.IsFalse(sut.IsEmpty());
        }


        [Test]
        public void CanPeekLastItem()
        {
            var sut = new Stack<Item>();
            var item1 = new Item();
            sut.Push(item1);
            Assert.AreEqual(item1, sut.Peek());
            var item2 = new Item();
            sut.Push(item2);
            Assert.AreEqual(item2, sut.Peek());
        }
        [Test]
        public void CanPopLastItem()
        {
            var sut = new Stack<Item>();
            var item1 = new Item();
            sut.Push(item1);
            Assert.AreEqual(item1, sut.Pop());
            Assert.IsTrue(sut.IsEmpty());
        }

        [Test]
        public void CanPopTwoItems()
        {
            var sut = new Stack<Item>();
            var item1 = new Item();
            sut.Push(item1);
            var item2 = new Item();
            sut.Push(item2);

            Assert.AreEqual(item2, sut.Pop());
            Assert.AreEqual(item1, sut.Pop());
            Assert.IsTrue(sut.IsEmpty());
        }
        [Test]
        public void PopEmptyStackThrows()
        {
            var sut = new Stack<Item>();
            
            Assert.Throws<StackEmptyException>(() => sut.Pop());
        }
        [Test]
        public void PeekEmptyStackThrows()
        {
            var sut = new Stack<Item>();

            Assert.Throws<StackEmptyException>(() => sut.Peek());
        }
    }
}
