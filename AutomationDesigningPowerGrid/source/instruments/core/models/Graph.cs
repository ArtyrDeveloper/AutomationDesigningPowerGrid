using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Graph
    {
        public int Id { get; set; }

        public List<Node> Nodes { get; set; }

        public List<Branch> Branches { get; set; }

        public Graph(List<Branch> branches, List<Node> nodes, int id)
        {
            Branches = branches;
            Nodes = nodes;
            Id = id;
        }

        public int GetMaximumNodesValue() =>  Nodes.Count; 

        public Node GetNodeById(int nodeId)
        {
            foreach (var node in Nodes)
            {
                if(node.Id == nodeId) return node;
            }
            throw new ArgumentException($"В данном графе отсутствует узел с ID {nodeId}");
        }
    }

    public class Node
    {
        public int Id { get; set; }

        public Node(int id)
        {
            Id = id;
        }
    }

    public class Branch
    {
        public int Id { get; set; }
        public Node NodeFrom { get; set; }
        public Node NodeTo { get; set; }

        public Branch(Node nodeFrom, Node nodeTo, int id)
        {
            Id = id;
            NodeFrom = nodeFrom;
            NodeTo = nodeTo;
        }
    }
}
