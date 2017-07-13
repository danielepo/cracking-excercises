using NUnit.Framework;

namespace StacksAndQueues
{
    [TestFixture]
    public class QueueTests
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
