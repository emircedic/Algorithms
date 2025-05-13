namespace Algorithms.Graph_Algorithms
{
    public class DFS
    {
        public IList<int> RecursiveDFS(TreeNode root)
        {
            List<int> result = new();
            RecursiveInternalInOrder(root, result);
            return result;
        }

        private void RecursiveInternalInOrder(TreeNode node, List<int> values)
        {
            if (node == null)
                return;

            RecursiveInternalInOrder(node.left, values);
            values.Add(node.val);
            RecursiveInternalInOrder(node.right, values);
        }

        private void RecursiveInternalPreOrder(TreeNode node, List<int> values)
        {
            if (node == null)
                return;

            values.Add(node.val);
            RecursiveInternalInOrder(node.left, values);
            RecursiveInternalInOrder(node.right, values);
        }

        private void RecursiveInternalPostOrder(TreeNode node, List<int> values)
        {
            if (node == null)
                return;

            RecursiveInternalInOrder(node.left, values);
            RecursiveInternalInOrder(node.right, values);
            values.Add(node.val);
        }



        public IList<int> IterativeDFS(TreeNode root)
        {
            List<int> result = new();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            // In-order traversal.

            // We have to specify 'root != null' for the following edge case: [1,null,2].
            // Stack would be empty but we still have the node '2' to process.
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

            // Pre-order traversal.
            while (root != null || stack.Count > 0)
            {
                if (root != null)
                {
                    Console.WriteLine(root.val);
                    if (root.right != null)
                    {
                        stack.Push(root.right);
                    }
                    root = root.left;
                }
                else
                {
                    root = stack.Pop();
                }
            }

            // Post-order traversal.
            Stack<bool> visit = new Stack<bool>();
            visit.Push(false);

            while (stack.Count > 0)
            {
                TreeNode curr = stack.Pop();
                bool visited = visit.Pop();
                if (curr != null)
                {
                    if (visited)
                    {
                        Console.WriteLine(curr.val);
                    }
                    else
                    {
                        stack.Push(curr);
                        visit.Push(true);
                        stack.Push(curr.right);
                        visit.Push(false);
                        stack.Push(curr.left);
                        visit.Push(false);
                    }
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
