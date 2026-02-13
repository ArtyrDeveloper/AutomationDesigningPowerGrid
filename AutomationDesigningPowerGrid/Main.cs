using System;
using System.Collections.Generic;
using Core.Algorithms;
using Core.Interface;

namespace AutomationDesigningPowerGrid
{
    public class Programm
    {
        static void Main(string[] args)
        {
            IPowerHandler powerHandler = new PowerHandler();
            var activePowers = new List<double>() { 19, 34, 22, 32 };
            double cos_fi = 0.9;
            var fullPowerVectors = powerHandler.GetAllFullPowerVector(activePowers, cos_fi);
            for(int i = 0; i < fullPowerVectors.Count; i++)
            {
                Console.WriteLine(fullPowerVectors[i]);
            }
           
        }
    }
}
