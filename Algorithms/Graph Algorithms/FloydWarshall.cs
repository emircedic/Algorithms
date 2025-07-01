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
        public const int INF = int.MaxValue / 2; // avoid overflow

        public int[,] ComputeShortestPaths(int[,] graph)
        {
            int V = graph.GetLength(0);
            int[,] dist = (int[,])graph.Clone();

            for (int k = 0; k < V; k++)
            {
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            // Optional: Detect negative cycles
            for (int i = 0; i < V; i++)
            {
                if (dist[i, i] < 0)
                    throw new InvalidOperationException("Graph contains a negative weight cycle.");
            }

            return dist;
        }

        /*
        Usage:

            int INF = FloydWarshall.INF;
            int[,] graph = {
                { 0,   3,   INF, 5 },
                { 2,   0,   INF, 4 },
                { INF, 1,   0,   INF },
                { INF, INF, 2,   0 }
            };

            var fw = new FloydWarshall();
            int[,] result = fw.ComputeShortestPaths(graph);
         */

    }
}
