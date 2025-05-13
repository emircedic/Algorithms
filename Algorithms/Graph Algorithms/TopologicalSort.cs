﻿namespace Algorithms.Graph_Algorithms
{
    public class TopologicalSort
    {
        public List<int> TopologicalSortInternal(int n, int[][] edges)
        {
            Dictionary<int, List<int>> adjacencyList = new();

            for (int i = 0; i < n; i++)
                adjacencyList.Add(i, new List<int>());

            foreach (var edge in edges)
                adjacencyList[edge[0]].Add(edge[1]);

            HashSet<int> path = new();
            HashSet<int> visitedVertices = new();
            List<int> result = new();

            for (int i = 0; i < n; i++)
            {
                var cyclePresent = DFS(i, visitedVertices, path, result, adjacencyList);
                if (cyclePresent)
                    return new List<int>();
            }

            result.Reverse();

            return result;
        }

        private bool DFS(int node, HashSet<int> visitedVertices, HashSet<int> path, List<int> result, Dictionary<int, List<int>> adjacencyList)
        {
            if (path.Contains(node))
                return true;

            if (visitedVertices.Contains(node))
                return false;

            path.Add(node);
            visitedVertices.Add(node);

            foreach (var childVertice in adjacencyList[node])
            {
                var cyclePresent = DFS(childVertice, visitedVertices, path, result, adjacencyList);

                if (cyclePresent)
                    return true;
            }

            path.Remove(node);
            result.Add(node);

            return false;
        }
    }
}
