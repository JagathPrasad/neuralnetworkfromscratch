using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        public NetworkLayer InputLayer = new NetworkLayer();
        public List<NetworkLayer> HiddenLayer = new List<NetworkLayer>();
        public NetworkLayer OutputLayer = new NetworkLayer();
        public double expectedOutput = 1;
        public double Bias { get; set; } = 1;
        double sum = 0.0;
        public NeuralNetwork()
        {

        }

        public void Initialize(int inputNeuron, int hiddenLayer, int hiddenNeuron, int outputNeuron)
        {
            Util utility = new Util();
            for (int i = 0; i < inputNeuron; i++)
            {
                Neuron neron = new Neuron();
                neron.Input = utility.NextDouble();
                neron.Weight = utility.NextDouble();
                InputLayer.NeuronList.Add(neron);
            }

            for (int i = 0; i < hiddenLayer; i++)
            {
                NetworkLayer networkLayer = new NetworkLayer();
                for (int j = 0; j < hiddenNeuron; j++)
                {
                    Neuron neuron = new Neuron();
                    neuron.Input = utility.NextDouble();
                    neuron.Weight = utility.NextDouble();
                    networkLayer.NeuronList.Add(neuron);

                }
                HiddenLayer.Add(networkLayer);
            }

            for (int i = 0; i < outputNeuron; i++)
            {
                Neuron neuron = new Neuron();
                neuron.Input = utility.NextDouble();
                neuron.Weight = utility.NextDouble();
                OutputLayer.NeuronList.Add(neuron);

            }
        }

        public void FeedForward()
        {

            foreach (var layer in InputLayer.NeuronList)
            {
                sum = sum + (layer.Input * layer.Weight);

            }
            sum = this.ActivationFunction(sum);//sigmoid
            for (int i = 0; i < HiddenLayer.Count; i++)
            {
                for (int y = 0; y < HiddenLayer[i].NeuronList.Count; y++)
                {
                    sum = sum + (HiddenLayer[i].NeuronList[y].Input * HiddenLayer[i].NeuronList[y].Weight);
                }
                sum = this.ActivationFunction(sum);//sigmoid
            }
            foreach (var layerOutput in OutputLayer.NeuronList)
            {
                sum = sum + (layerOutput.Input * layerOutput.Weight);
            }
            sum = this.ActivationFunction(sum);//sigmoid
            OutputLayer.Output = sum;
            if (sum < 0.0)
            {
                sum = sum + 1;//added bias.
            }

            if (sum < expectedOutput)
            {
                BackProPagation(sum);//backpropagation
            }
            Console.WriteLine($"The Output is :{OutputLayer.Output}");
        }

        public void BackProPagation(double error)
        {
            Util util = new Util();
            //double sum = 0.0;
            double learningRate = 0.05;
            double delta = 0.0;
            var Loss = Math.Pow(error - expectedOutput, 2);
            OutputLayer.Error = Loss;
            sum = Loss;
            delta = delta * util.Derivative(sum);
            //delta = sum * (1 - sum) * (expectedOutput - sum);
            //calculate error
            foreach (var x in HiddenLayer)
            {
                foreach (var y in x.NeuronList)
                {

                    sum = sum + y.Weight * delta;

                }
                //delta = sum * (1 - sum) * delta;
                sum = util.Derivative(sum);//sigmoid derivative
                delta = sum;
            }
            //update weight and bias.
            foreach (var x in HiddenLayer)
            {
                foreach (var y in x.NeuronList)
                {
                    y.Weight = (learningRate * delta * OutputLayer.Output) + y.Weight;
                }
            }
            foreach (var x in InputLayer.NeuronList)
            {
                x.Weight = (learningRate * delta * OutputLayer.Output) + x.Weight;
            }

        }


        public double ActivationFunction(double input)
        {
            Util utility = new Util();
            return utility.SigMoid(input);
        }

        //public double Derivative(double input)
        //{

        //}
    }
}
