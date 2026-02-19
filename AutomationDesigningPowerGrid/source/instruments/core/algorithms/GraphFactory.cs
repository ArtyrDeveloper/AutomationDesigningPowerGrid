using Core.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Core.Algorithms
{
    public class GraphFactory
    {
        private GraphHandler _handler;

        public GraphFactory(GraphHandler handler)
        {
            _handler = handler; 
        }

        public Graph GetGraph(int characterizingNumber, int maximumNodesValue, int id)
        {
            

            var structureCode = _handler.GetStructureCode(characterizingNumber, maximumNodesValue);
            var nodes = new List<Node>();
            var branches = new List<Branch>();

            for (int i = 0; i < maximumNodesValue; i++)
            {
                nodes.Add(new Node(i));
            }

            int bitIndex = 0;
            int branchCount = 0;

            for (int i = 0; i < maximumNodesValue; i++)
            {
                for (int j = i + 1; j < maximumNodesValue; j++)
                {
                    // Если бит равен '1', добавляем ребро
                    if (structureCode[bitIndex] == '1')
                    {

                        var branch1 = new Branch(nodes[i], nodes[j], branchCount);
                        var branch2 = new Branch(nodes[j], nodes[i], branchCount + 1);
                        branches.Add(branch1);
                        branches.Add(branch2);
                    }
                    bitIndex++;
                    branchCount += 2;
                }
            }

            var graph = new Graph(branches, nodes, id);

            return graph;
        }

        private Node GetNodeById(List<Node> nodes, int nodeId)
        {
            foreach (var node in nodes)
            {
                if (node.Id == nodeId) return node;
            }
            throw new ArgumentException($"В данном графе отсутствует узел с ID {nodeId}");
        }
    }

    public class GraphHandler
    { 
        public string GetStructureCode(int characterizingNumber, int maximumNodesValue)
        {
            var maximumBranchesValue = maximumNodesValue * (maximumNodesValue - 1) / 2;

            var binaryCharacterizingNumber = Convert.ToString(characterizingNumber, 2);

            if (binaryCharacterizingNumber.Length > maximumBranchesValue)
            {
                throw new ArgumentException($"Характеризующее число графа {characterizingNumber} не может соотвествовать графу с {maximumNodesValue} вершин");
            }
            else if (binaryCharacterizingNumber.Length < maximumBranchesValue)
            {
                binaryCharacterizingNumber = binaryCharacterizingNumber.PadLeft(maximumBranchesValue, '0');
            }

            return binaryCharacterizingNumber;
        }

        public List<int>[] GetAdjacencyList(Graph graph)
        {
            var maximumNodesValue = graph.GetMaximumNodesValue();

            List<int>[] adjacencyList = new List<int>[maximumNodesValue];

            for (int i = 0; i < maximumNodesValue; i++)
            {
                adjacencyList[i] = new List<int>();
            }
            foreach (var branch in graph.Branches)
            {
                adjacencyList[branch.NodeFrom.Id].Add(branch.NodeTo.Id);
                adjacencyList[branch.NodeTo.Id].Add(branch.NodeFrom.Id);
            }
            return adjacencyList;
        }

        public bool IsConnectedGraph(Graph graph)
        {
            var adjacencyList = GetAdjacencyList(graph);

            int n = adjacencyList.Length;
            bool[] visited = new bool[n];
            Stack<int> stack = new Stack<int>();

            stack.Push(0);
            visited[0] = true;
            int count = 1;

            while (stack.Count > 0)
            {
                int vertex = stack.Pop();

                foreach (int neighbor in adjacencyList[vertex])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        stack.Push(neighbor);
                        count++;
                    }
                }
            }

            return count == n;
        }
    }
}
