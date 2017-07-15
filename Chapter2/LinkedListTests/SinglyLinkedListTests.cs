using NUnit.Framework;
using System;
using DataStructures;
namespace LinkedListTests
{
    [TestFixture]
    [Category("Linked Lists")]
    public class SinglyLinkedListTests
    {
        private LinkedList<Item> sut;
        [SetUp]
        public void SetUp()
        {
            sut = new LinkedList<Item>();
        }
        [Test]
        public void EmptyListIsEmpty()
        {
            Assert.That(sut.IsEmpty, Is.True);
        }

        [Test]
        public void CanAddItem()
        {
            sut.AppendToTail(new Item());
            Assert.That(sut.IsEmpty, Is.False);
        }

        [Test]
        public void AppendToTailDoenstChangesHead()
        {
            var item1 = new Item();
            sut.AppendToTail(item1);
            sut.AppendToTail(new Item());
            Assert.That(sut.Head.Value, Is.EqualTo(item1));
        }
        [Test]
        public void CanAccessEveryItemInSequence()
        {
            var item1 = new Item();
            var item2 = new Item();
            var item3 = new Item();
            sut.AppendToTail(item1);
            sut.AppendToTail(item2);
            sut.AppendToTail(item3);

            var head = sut.Head;
            Assert.That(head.Value, Is.EqualTo(item1));
            Assert.That(head.Next.Value, Is.EqualTo(item2));
            Assert.That(head.Next.Next.Value, Is.EqualTo(item3));
            Assert.That(head.Next.Next.Next, Is.EqualTo(null));
        }
        [Test]
        public void DeletingTheHeadRedefinesTheHeadAsTheSecondElement()
        {
            var item1 = new Item();
            var item2 = new Item();
            var item3 = new Item();
            sut.AppendToTail(item1);
            sut.AppendToTail(item2);
            sut.AppendToTail(item3);

            var head = sut.Head;
            sut.Delete(item1);
            Assert.That(sut.Head.Value, Is.EqualTo(item2));

        }

        [Test]
        public void DeletingReturnsTheDeletedNode()
        {
            var item1 = new Item();
            sut.AppendToTail(item1);
            var head = sut.Head;
            var returned = sut.Delete(item1);
            Assert.That(returned.Value, Is.EqualTo(item1));
        }
        [Test]
        public void DeletingFromMiddleRemovesElement()
        {
            var item1 = new Item();
            var item2 = new Item();
            var item3 = new Item();
            sut.AppendToTail(item1);
            sut.AppendToTail(item2);
            sut.AppendToTail(item3);

            var head = sut.Head;
            sut.Delete(item2);
            Assert.That(sut.Head.Value, Is.EqualTo(item1));
            Assert.That(sut.Head.Next.Value, Is.EqualTo(item3));
            Assert.That(sut.Head.Next.Next, Is.EqualTo(null));

        }

        [Test]
        public void CanDeleteAfterSpecificNode()
        {
            var item1 = new Item();
            var item2 = new Item();
            var item3 = new Item();
            sut.AppendToTail(item1);
            sut.AppendToTail(item2);
            sut.AppendToTail(item1);

            var head = sut.Head;
            sut.Delete(item1,head);

            Assert.That(sut.Head.Value, Is.EqualTo(item1));
            Assert.That(sut.Head.Next.Value, Is.EqualTo(item2));
            Assert.That(sut.Head.Next.Next, Is.EqualTo(null));

        }
        [Test]
        public void CanFindElementInList()
        {
            var item1 = new Item();
            var item2 = new Item();
            var item3 = new Item();
            sut.AppendToTail(item1);
            sut.AppendToTail(item2);
            sut.AppendToTail(item3);

            var found = sut.Find(item2);
            Assert.That(found.Value, Is.EqualTo(item2));
        }

        [Test]
        public void CanLookupElementAfterAnoter()
        {
            var item1 = new Item();
            var item2 = new Item();
            var item3 = new Item();
            sut.AppendToTail(item1);
            sut.AppendToTail(item2);
            sut.AppendToTail(item1);

            var node1= sut.Find(item1);
            var found = sut.Find(item1, node1);
            Assert.That(found, Is.Not.EqualTo(node1));

            Assert.That(found.Value, Is.EqualTo(item1));
        }
    }
}