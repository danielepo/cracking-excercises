using System;
using NUnit.Framework;
using DataStructures.Trees;
using System.Collections.Generic;

namespace TreesAndGraphsTests
{
    [TestFixture]
    public class InOrderTraversalTests
    {
        [Test]
        public void ANodeWithoutChildTraversesSaidNode()
        {
            var singleNode = new BinaryTreeNode<int>()
            {
                Value = 1
            };
            var sut = new Traversers<int>();
            var list = new List<int>();
            sut.InOrderTraversal(singleNode, x => list.Add(x));
            Assert.That(list[0], Is.EqualTo(1));
        }
        [Test]
        public void TreeWithOnlyLeftNodesTraversesTheTreeFromBottom()
        {
            var singleNode = new BinaryTreeNode<int>()
            {
                Value = 1,
                LeftNode = new BinaryTreeNode<int>()
                {
                    Value = 2,
                    LeftNode = new BinaryTreeNode<int>()
                    {
                        Value = 3
                    }
                }
            };
            var sut = new Traversers<int>();
            var list = new List<int>();
            sut.InOrderTraversal(singleNode, x => list.Add(x));
            Assert.That(list[0], Is.EqualTo(3));
            Assert.That(list[1], Is.EqualTo(2));
            Assert.That(list[2], Is.EqualTo(1));
        }

        [Test]
        public void TreeWithOnlyRightNodesTraversesTheTreeFromBottom()
        {
            var singleNode = new BinaryTreeNode<int>()
            {
                Value = 1,
                RightNode = new BinaryTreeNode<int>()
                {
                    Value = 2,
                    RightNode = new BinaryTreeNode<int>()
                    {
                        Value = 3
                    }
                }
            };
            var sut = new Traversers<int>();
            var list = new List<int>();
            sut.InOrderTraversal(singleNode, x => list.Add(x));
            Assert.That(list[0], Is.EqualTo(1));
            Assert.That(list[1], Is.EqualTo(2));
            Assert.That(list[2], Is.EqualTo(3));
        }

        [Test]
        public void IoTOfComplexTree()
        {
            var singleNode = new BinaryTreeNode<int>()
            {
                Value = 1,
                LeftNode = new BinaryTreeNode<int>
                {
                    Value = 5,
                    LeftNode = new BinaryTreeNode<int>
                    {
                        Value = 6
                    },
                    RightNode = new BinaryTreeNode<int>
                    {
                        Value = 7,
                        LeftNode = new BinaryTreeNode<int>
                        {
                            Value = 8
                        }

                    }
                },
                RightNode = new BinaryTreeNode<int>()
                {
                    Value = 2,
                    RightNode = new BinaryTreeNode<int>()
                    {
                        Value = 3
                    },
                    LeftNode = new BinaryTreeNode<int>
                    {
                        Value = 9
                    }

                }
            };
            var sut = new Traversers<int>();
            var list = new List<int>();
            sut.InOrderTraversal(singleNode, x => list.Add(x));
            Assert.That(list[0], Is.EqualTo(6));
            Assert.That(list[1], Is.EqualTo(5));
            Assert.That(list[2], Is.EqualTo(8));
            Assert.That(list[3], Is.EqualTo(7));
            Assert.That(list[4], Is.EqualTo(1));
            Assert.That(list[5], Is.EqualTo(9));
            Assert.That(list[6], Is.EqualTo(2));
            Assert.That(list[7], Is.EqualTo(3));
        }


    }
}
