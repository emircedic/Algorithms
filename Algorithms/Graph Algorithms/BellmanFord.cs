namespace Algorithms.Graph_Algorithms
{
    // Used to determine shortest path on weighted graph with negative values with a set start-node.
    // Unlike Dijkstra's algorithm, Bellman-Ford works on negative weight values.

    // Time complexity: O (V * E)
    // Space complexity: O (V + E)

    // E - Edge
    // V - Vertex (node)
    public class BellmanFord
    {
        public int[] ComputeShortestPaths(List<Edge> edges, int vertexCount, int source)
        {
            int[] distance = new int[vertexCount];
            Array.Fill(distance, int.MaxValue);
            distance[source] = 0;

            for (int i = 0; i < vertexCount - 1; i++)
            {
                foreach (var edge in edges)
                {
                    if (distance[edge.Source] != int.MaxValue &&
                        distance[edge.Source] + edge.Weight < distance[edge.Destination])
                    {
                        distance[edge.Destination] = distance[edge.Source] + edge.Weight;
                    }
                }
            }

            // Negative cycle detection
            foreach (var edge in edges)
            {
                if (distance[edge.Source] != int.MaxValue &&
                    distance[edge.Source] + edge.Weight < distance[edge.Destination])
                {
                    throw new InvalidOperationException("Graph contains a negative weight cycle.");
                }
            }

            return distance;
        }
    }

    public class Edge
    {
        public int Source;
        public int Destination;
        public int Weight;
    }

    /*
    Usage:

        var edges = new List<Edge>
        {
            new Edge { Source = 0, Destination = 1, Weight = 4 },
            new Edge { Source = 0, Destination = 2, Weight = 5 },
            new Edge { Source = 1, Destination = 2, Weight = -3 },
            new Edge { Source = 2, Destination = 3, Weight = 4 }
        };

        int vertexCount = 4;
        int source = 0;

        var bf = new BellmanFord();
        int[] distances = bf.ComputeShortestPaths(edges, vertexCount, source);      
     */
}
