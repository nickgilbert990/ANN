﻿using PrototypeNeuralNetwork.Synapses;
using System;
using System.Collections.Generic;

namespace PrototypeNeuralNetwork.Neuron
{
    /// <summary>
    /// Interface for Neuron.
    /// </summary>
    public interface INeuron
    {
        Guid Id { get; }
        double PreviousPartialDerivate { get; set; }

        List<ISynapse> Inputs { get; set; }
        List<ISynapse> Outputs { get; set; }

        void AddInputNeuron(INeuron inputNeuron);
        void AddOutputNeuron(INeuron inputNeuron);
        double CalculateOutput();

        void AddInputSynapse(double inputValue);
        void PushValueOnInput(double inputValue);
    }
}