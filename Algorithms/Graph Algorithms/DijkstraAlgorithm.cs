namespace Algorithms.Graph_Algorithms
{
    // Space complexity: O(E log E)
    // Worst case scenario we insert/remove every edge from the Min Heap.

    // Time complexity: O(E)
    
    // E represents the edges.
    public class DijkstraAlgorithm
    {
        public Dictionary<int, int> ShortestPath(int n, List<List<int>> edges, int src)
        {
            Dictionary<int, int> result = new();

            Dictionary<int, List<(int name, int weight)>> adjacencyList = new();

            for (int i = 0; i < n; i++)
            {
                result.Add(i, -1);
                adjacencyList.Add(i, new List<(int name, int weight)>());
            }

            // Define adjacency list using provided edges.
            foreach (var edge in edges)
            {
                var source = edge[0];
                var destination = edge[1];
                var weight = edge[2];

                adjacencyList[source].Add((destination, weight));
            }

            PriorityQueue<(int name, int weight), int> minHeap = new();
            minHeap.Enqueue((src, 0), 0);

            while (minHeap.Count > 0)
            {
                var node = minHeap.Dequeue();
                (int nodeName, int nodeWeight) = node;

                if (result[nodeName] != -1)
                    continue;

                result[nodeName] = nodeWeight;

                foreach (var neighbourNode in adjacencyList[nodeName])
                {
                    (int neighbourName, int neighbourWeight) = neighbourNode;

                    if (result[neighbourName] == -1)
                        minHeap.Enqueue((neighbourName, neighbourWeight + nodeWeight), neighbourWeight + nodeWeight);
                }
            }

            return result;
        }
    }
}
