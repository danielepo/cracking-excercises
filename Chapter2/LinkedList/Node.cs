using System.Collections.Generic;

namespace LinkedLists
{
    public class Node
    {
        private Node next;
        private readonly int value;
        public Node(int value)
        {
            this.value = value;
        }

        public int Value{get { return this.value; }}

        public void addToTail(int val)
        {
            Node n = FindTail();
            n.next = new Node(val);
        }

        private Node FindTail()
        {
            var n = this;
            while (n.next != null)
            {
                n = n.next;
            }
            return n;
        }
    }
}
