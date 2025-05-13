namespace Algorithms.Graph_Algorithms
{
    public class PrimAlgorithm
    {
        public int MinimumSpanningTree(int n, List<List<int>> edges)
        {
            // ToDo: Possibly could be improved to exclude 'sourceNode'.

            int totalGraphWeight = 0;

            // Initialize and set default empty lists for each node.
            Dictionary<int, List<(int sourceNode, int destinationNode, int weight)>> adjacencyList = new();
            for (int i = 0; i < n; i++)
                adjacencyList.Add(i, new List<(int sourceNode, int destinationNode, int weight)>());

            // Define all edges for each node.
            foreach (var edge in edges)
            {
                var firstNode = edge[0];
                var secondNode = edge[1];
                var weight = edge[2];

                adjacencyList[firstNode].Add((firstNode, secondNode, weight));
                adjacencyList[secondNode].Add((secondNode, firstNode, weight));
            }

            // Initialize min heap and add all neighbouring nodes to first node.
            PriorityQueue<(int startNode, int destinationNode, int weight), int> minHeap = new();
            foreach (var node in adjacencyList[0])
                minHeap.Enqueue((node.sourceNode, node.destinationNode, node.weight), node.weight);

            HashSet<int> processedNodes = new();
            processedNodes.Add(0);

            while (minHeap.Count > 0)
            {
                (int sourceNode, int destinationNode, int weight) = minHeap.Dequeue();

                // Works on the principle that the source node has been already processed.
                // It works the same as Dijkstras algorithm, but with the caveat being that we need to know what is the source node.
                // We need to know the previous node from where we came to the current one to be able to define the edge.
                // In previous problems we worked with destination nodes as well but because we did not care about previous node, we only referenced destination node.

                if (!processedNodes.Contains(destinationNode))
                {
                    processedNodes.Add(destinationNode);
                    totalGraphWeight += weight;

                    foreach (var node in adjacencyList[destinationNode])
                        minHeap.Enqueue((node.sourceNode, node.destinationNode, node.weight), node.weight);
                }
            }

            return processedNodes.Count != n ? -1 : totalGraphWeight;
        }
    }
}
