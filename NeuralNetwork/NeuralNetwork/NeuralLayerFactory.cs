using PrototypeNeuralNetwork.ActivationFunctions;
using PrototypeNeuralNetwork.InputFunctions;

namespace PrototypeNeuralNetwork
{
    /// <summary>
    /// Factory used to create layers.
    /// </summary>
    public class NeuralLayerFactory
    {
        public NeuralLayer CreateNeuralLayer(int numberOfNeurons, IActivationFunction activationFunction, IInputFunction inputFunction)
        {
            var layer = new NeuralLayer();

            for (int i = 0; i < numberOfNeurons; i++)
            {
                var neuron = new Neuron.Neuron(activationFunction, inputFunction);
                layer.Neurons.Add(neuron);
            }

            return layer;
        }
    }
}
