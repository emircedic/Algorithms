namespace Algorithms.Graph_Algorithms
{
    public class BFS
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new();

            Queue<TreeNode> queue = new();

            if (root != null)
                queue.Enqueue(root);

            while (queue.Count > 0)
            {
                List<int> rowValues = new();

                int countPerRow = queue.Count;

                for (int i = 0; i < countPerRow; i++)
                {
                    var node = queue.Dequeue();
                    rowValues.Add(node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);

                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                result.Add(rowValues);
            }

            return result;
        }
    }
}
