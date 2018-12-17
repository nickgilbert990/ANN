using PrototypeNeuralNetwork.Synapses;
using System.Collections.Generic;

namespace PrototypeNeuralNetwork.InputFunctions
{
    /// <summary>
    /// Interface for Input Functions.
    /// </summary>
    public interface IInputFunction
    {
        double CalculateInput(List<ISynapse> inputs);
    }
}