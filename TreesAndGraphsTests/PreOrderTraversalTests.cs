using NUnit.Framework;
using DataStructures.Trees;
using System.Collections.Generic;

namespace TreesAndGraphsTests
{
    [TestFixture]
    public class PreOrderTraversalTests
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
            sut.PreOrderTraversal(singleNode, x => list.Add(x));
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
            sut.PreOrderTraversal(singleNode, x => list.Add(x));
            AssertPostions(new int[] { 1, 2, 3 }, list);
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
            sut.PreOrderTraversal(singleNode, x => list.Add(x));
            AssertPostions(new int[] { 1, 2, 3 }, list);
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
            sut.PreOrderTraversal(singleNode, x => list.Add(x));

            AssertPostions(new int[] { 1, 5, 6, 7, 8, 2, 9, 3 }, list);

        }
        private void AssertPostions(int[] values, List<int> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var elm = list[i];
                Assert.That(elm, Is.EqualTo(values[i]));
            }
        }

    }
}
