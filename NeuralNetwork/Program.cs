using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork neuralNetwork = new NeuralNetwork();
            neuralNetwork.Initialize(2,1,2,1);
            for (int i = 0; i < 150; i++)
            {
                neuralNetwork.FeedForward();
             
            }
            Console.ReadLine();
            

        }
    }
}
