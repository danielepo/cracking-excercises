using System;

namespace DataStructures.Trees
{
    public class Traversers<T>
    {
        /// <summary>
        /// Visits first the left childs then the node then the right childs
        /// When performed on a Binary Search Tre it traveses the tree in increasing order
        /// </summary>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public void InOrderTraversal(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node.LeftNode != null)
            {
                InOrderTraversal(node.LeftNode, action);
            }
            action(node.Value);
            if (node.RightNode != null)
            {
                InOrderTraversal(node.RightNode, action);
            }
        }
        /// <summary>
        /// visits first the node then it's childs
        /// </summary>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public void PreOrderTraversal(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null) return;
            action(node.Value);
            PreOrderTraversal(node.LeftNode, action);
            PreOrderTraversal(node.RightNode, action);
        }

        /// <summary>
        /// visists the current node after it's childs
        /// </summary>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public void PostOrderTraversal(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null) return;
            PostOrderTraversal(node.LeftNode, action);
            PostOrderTraversal(node.RightNode, action);
            action(node.Value);
        }
    }
}
