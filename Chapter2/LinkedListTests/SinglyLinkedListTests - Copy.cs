using NUnit.Framework;
using System;
using DataStructures;
namespace LinkedListTests
{
    [TestFixture]
    [Category("Linked Lists Problems")]
    public class Problem_2_1
    {
        private LinkedList<int> sut;
        [SetUp]
        public void SetUp()
        {
            sut = new LinkedList<int>();
            sut.AppendToTail(5);
            sut.AppendToTail(2);
            sut.AppendToTail(1);
            sut.AppendToTail(3);
            sut.AppendToTail(2);
            sut.AppendToTail(4);
            sut.AppendToTail(0);
        }
        [Test]
        public void RemoveDuplicateTest()
        {
            RemoveDuplicate(sut);
            var next = sut.Head;
            Assert.That(next.Value, Is.EqualTo(5));
            next = next.Next;
            Assert.That(next.Value, Is.EqualTo(2));
            next = next.Next;
            Assert.That(next.Value, Is.EqualTo(1));
            next = next.Next;
            Assert.That(next.Value, Is.EqualTo(3));
            next = next.Next;
            Assert.That(next.Value, Is.EqualTo(4));
            next = next.Next;
            Assert.That(next.Value, Is.EqualTo(0));
        }
        /// <summary>
        /// I can run it with two indexes
        ///  - one of the current node
        ///  - one that goes to the end every time
        ///  
        /// 
        /// # Running Time
        /// if n = 5 then
        ///     5 for the first index
        ///     4 + 3 + 2 + 1 = n(n+1)/2 -> n^2
        ///     
        /// </summary>
        /// <param name="sut"></param>
        private void RemoveDuplicate(LinkedList<int> sut)
        {
            var current = sut.Head;

            while(current.Next != null)
            {
                var fast = current.Next;
                var found = sut.Delete(current.Value, fast);
                current= current.Next;
            }
        }
    }
}