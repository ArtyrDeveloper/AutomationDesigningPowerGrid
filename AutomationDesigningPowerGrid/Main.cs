using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Algorithms;
using Core.Interface;
using Core.Models;
using Instruments.Json;

namespace AutomationDesigningPowerGrid
{
    public class Programm
    {
        static void Main(string[] args)
        {
            var handler = new GraphHandler();
            var graphFabric = new GraphFactory(handler);
           
            var maxValue = Convert.ToInt32(Math.Pow(2, 15) - 1);
            var connectedGraphs = new List<Graph>();

            for (int i = 0; i < maxValue;  i++)
            {
                var graph = graphFabric.GetGraph(i, 6, i);
                var structureCode = handler.GetStructureCode(i, 6);
                var isConnectedGraph = handler.IsConnectedGraph(graph);
                if (isConnectedGraph)
                {
                    connectedGraphs.Add(graph);
                }
                Console.WriteLine($"Граф с числом {i} и структурным кодом {structureCode} имеет связность: {isConnectedGraph}\n");
            }

            var jsonFileRepository = new JsonFileRepository<Graph>();
            jsonFileRepository.WriteAll("D:\\connected_graph_database", connectedGraphs);
            Console.WriteLine("Done");
        }
    }
}
