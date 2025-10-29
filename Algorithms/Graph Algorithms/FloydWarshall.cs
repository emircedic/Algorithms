namespace Algorithms.Graph_Algorithms
{
    // Used to determine shortest path on weighted graph with negative values without a set start-node.
    // Unlike Dijkstra's algorithm, Floyd-Warshall works on negative weight values.

    // Time complexity: O (V^3)
    // Space complexity: O (V^2)

    // E - Edge
    // V - Vertex (node)
    public class FloydWarshall
    {
        public const int INF = int.MaxValue / 2; // Prevent overflow
    
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            int[,] nodeDistance = new int[n, n];
    
            // Initialize distances
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    nodeDistance[i, j] = i == j ? 0 : INF;
            }
    
            // Populate edges
            foreach (var edge in times)
            {
                int u = edge[0] - 1;
                int v = edge[1] - 1;
                int w = edge[2];
                nodeDistance[u, v] = w;
            }
    
            // Floyd–Warshall algorithm
            for (int via = 0; via < n; via++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (nodeDistance[i, via] + nodeDistance[via, j] < nodeDistance[i, j])
                            nodeDistance[i, j] = nodeDistance[i, via] + nodeDistance[via, j];
                    }
                }
            }
    
            // Extract result: max distance from start node k
            int maxTime = 0;
            for (int target = 0; target < n; target++)
            {
                int time = nodeDistance[k - 1, target];
                if (time >= INF)
                    return -1;
    
                maxTime = Math.Max(maxTime, time);
            }
    
            return maxTime;
        }
    }
}
