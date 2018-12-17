using System.Collections.Generic;
using PrototypeNeuralNetwork.Synapses;
using System.Linq;

namespace PrototypeNeuralNetwork.InputFunctions
{
    /// <summary>
    /// Implementation of Weighted Sum Function.
    /// </summary>
    public class WeightedSumFunction : IInputFunction
    {
        public double CalculateInput(List<ISynapse> inputs)
        {
            return inputs.Select(x => x.Weight * x.GetOutput()).Sum();
        }
    }
}