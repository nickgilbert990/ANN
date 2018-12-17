using PrototypeNeuralNetwork.Neuron;
using System.Collections.Generic;
using System.Linq;

namespace PrototypeNeuralNetwork
{
    /// <summary>
    /// Implementation of a single layer in Artificial Neural Network.
    /// </summary>
    public class NeuralLayer
    {
        public List<INeuron> Neurons;

        public NeuralLayer()
        {
            Neurons = new List<INeuron>();
        }

        /// <summary>
        /// Flattens the inputLayer list (using SelectMany), generates a new layer with a lambda function
        /// and connects the neurons (each neuron has n output neurons) of the new layer to the existing layer
        /// using input and output neuron GUIDs - the inter neuron connection data is held in the
        /// connecting synapse.
        /// </summary>
        public void ConnectLayers(NeuralLayer inputLayer)
        {
            var combos = Neurons.SelectMany(neuron => inputLayer.Neurons, (neuron, input) => new { neuron, input });
            combos.ToList().ForEach(x => x.neuron.AddInputNeuron(x.input));
        }
    }
}