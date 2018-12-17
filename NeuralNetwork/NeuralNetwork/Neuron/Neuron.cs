using PrototypeNeuralNetwork.ActivationFunctions;
using PrototypeNeuralNetwork.InputFunctions;
using PrototypeNeuralNetwork.Synapses;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PrototypeNeuralNetwork.Neuron
{
    /// <summary>
    /// Neuron implementation.
    /// </summary>
    public class Neuron : INeuron
    {
        private IActivationFunction _activationFunction;
        private IInputFunction _inputFunction;

        /// <summary>
        /// Neuron input connections.
        /// </summary>
        public List<ISynapse> Inputs { get; set; }

        /// <summary>
        /// Neuron output connections.
        /// </summary>
        public List<ISynapse> Outputs { get; set; }

        public Guid Id { get; private set; }

        /// <summary>
        /// Neuron constructor
        /// </summary>
        public Neuron(IActivationFunction activationFunction, IInputFunction inputFunction)
        {
            Id = Guid.NewGuid();
            Inputs = new List<ISynapse>();
            Outputs = new List<ISynapse>();

            _activationFunction = activationFunction;
            _inputFunction = inputFunction;
        }

        /// <summary>
        /// Input Layer neurons receive input values from the InputSynapse. This method
        /// adds the InputSynapse connection to the input layer neuron and sets "inputValue"
        /// Note: as this prototype is extended to use real world inputs the inputValue
        /// will need to be derived from external logic.  
        /// </summary>
        public void AddInputSynapse(double inputValue)
        {
            var inputSynapse = new InputSynapse(this, inputValue);
            Inputs.Add(inputSynapse);
        }

        /// <summary>
        /// Calculated partial derivate in previous iteration of training process.
        /// </summary>
        public double PreviousPartialDerivate { get; set; }

        /// <summary>
        /// This method connects two neurons via a synapse. The inputNeuron parameter
        /// will be input neuron of the newly created connection.
        /// </summary>
        public void AddInputNeuron(INeuron inputNeuron)
        {
            var synapse = new Synapse(inputNeuron, this);
            Inputs.Add(synapse);
            inputNeuron.Outputs.Add(synapse);
        }

        /// <summary>
        /// This method connects two neurons via a synapse. The outputNeuron parameter
        /// will be output neuron of the newly created connection.
        /// </summary>
        public void AddOutputNeuron(INeuron outputNeuron)
        {
            var synapse = new Synapse(this, outputNeuron);
            Outputs.Add(synapse);
            outputNeuron.Inputs.Add(synapse);
        }

        /// <summary>
        /// Calculate output value of the neuron.
        /// </summary>
        /// <returns>
        /// Output of the neuron.
        /// </returns>
        public double CalculateOutput()
        {
            return _activationFunction.CalculateOutput(_inputFunction.CalculateInput(this.Inputs));
        }

        /// <summary>
        /// Sets new value on the input connections.
        /// </summary>
        /// <param name="inputValue">
        /// New value that will be "pushed" as an input to connection.
        /// </param>
        public void PushValueOnInput(double inputValue)
        {
            ((InputSynapse)Inputs.First()).Output = inputValue;
        }
    }
}