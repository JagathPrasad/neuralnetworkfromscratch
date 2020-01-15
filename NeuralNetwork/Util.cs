using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Util
    {
        /*
         It return the double values between 0.0 to lessthan 1.0
             */
        public double NextDouble()
        {
            Random rand = new Random();
            return rand.NextDouble();
        }

        //public double NextGaussian()
        //{
        //    Random rand = new Random();
        //    return rand.NextDouble();
        //}

        public double SigMoid(double value)
        {
            var sigMoid = 1.0 / (1.0 + Math.Exp(-value));
            return sigMoid;
        }


        public double Loss(double actual, double expected)
        {
            var loss = (actual - expected);
            return loss * loss;
        }

        public double MSE(double loss)
        {
            return loss;
        }

        public double Derivative(double input)
        {
            return SigMoid(input) * (1 - SigMoid(input));
        }

    }
}
