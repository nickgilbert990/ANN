
namespace PrototypeNeuralNetwork.ActivationFunctions
{
    /// <summary>
    /// Interface for activation functions.
    /// </summary>
    public interface IActivationFunction
    {
        double CalculateOutput(double input);
    }
}