using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrototypeNeuralNetwork;
using PrototypeNeuralNetwork.ActivationFunctions;
using PrototypeNeuralNetwork.InputFunctions;

namespace NeuralNetworkFactoryTests
{
    [TestClass]
    public class NeuralLayerFactoryTest
    {
        [TestMethod]
        public void CreateNeuralLayer_NumberOfNeuronsPasses_CorrectLayerCreated()
        {
            var neuralLayerFactory = new NeuralLayerFactory();
            var neuralLayer = neuralLayerFactory.CreateNeuralLayer(11, new StepActivationFunction(0.5), new WeightedSumFunction());

            Assert.AreEqual(11, neuralLayer.Neurons.Count);
        }
    }
}