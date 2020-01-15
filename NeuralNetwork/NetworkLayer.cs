using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NetworkLayer
    {
        //public List<Neuron> InputLayer = new List<Neuron>();
        //public List<List<Neuron>> HiddenLayer = new List<List<Neuron>>();
        //public List<Neuron> OutputLayer = new List<Neuron>();
        public List<Neuron> NeuronList = new List<Neuron>();
        public double Error { get; set; }
        public double Bias { get; set; } = 1;

        public double Output { get; set; }


        public NetworkLayer(string layerName)
        {


        }
        public NetworkLayer()
        {


        }
    }
}
