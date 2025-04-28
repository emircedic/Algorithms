namespace Algorithms.Graph_Algorithms
{
    public class DFS
    {
        public IList<int> RecursiveDFS(TreeNode root)
        {
            List<int> result = new();
            RecursiveInternal(root, result);
            return result;
        }

        private void RecursiveInternal(TreeNode node, List<int> values)
        {
            if (node == null)
                return;

            RecursiveInternal(node.left, values);
            values.Add(node.val);
            RecursiveInternal(node.right, values);
        }



        public IList<int> IterativeDFS(TreeNode root)
        {
            List<int> result = new();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (root != null || stack.Count > 0)
            {
                if (root == null)
                {
                    var tempNode = stack.Pop();
                    result.Add(tempNode.val);
                    root = tempNode.right;
                }
                else
                {
                    stack.Push(root);
                    root = root.left;
                }
            }

            return result;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
