using DataStructures.Exceptions;
namespace DataStructures.Trees
{

    /// <summary>
    /// Recrusive Explanation
    ///  - Each tree has a Root Node
    ///  - The Root is a Node
    ///  - Each Node has zero or more child Nodes
    ///  
    /// Cannot contain cycles but may have links to the parent nodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T>[] Children { get; }
    }

    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }
    }
    /// <summary>
    /// *A bynary tree* has all nodes with at most two childs
    /// *A bynary search tree* is a bynary tree in which every node fits a specific ordering property
    ///  - all left descendants <= n < all right for each node           >
    ///   - beware of the definition that could vary
    ///   
    ///          8
    ///         / \
    ///        4   10
    ///       / \    \
    ///      2   6    15
    /// 
    /// *Balanced trees* are intendend not to be "terribly" inbalanced. 
    ///  - insert and find happens in O(log n)
    ///  - lookup: Red-Black trees, and AVL trees
    ///  
    /// *Complete Binary trees* are filled completelly, the last layer can be not completed but it has to be filled left to rigth
    /// *Full Binary Trees* every node has either zero or two childs
    /// *Perfect Binary* are complete and full
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> LeftNode { get; set; }
        public BinaryTreeNode<T> RightNode { get; set; }
    }
}
