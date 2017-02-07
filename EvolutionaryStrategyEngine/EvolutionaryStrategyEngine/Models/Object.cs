﻿using System;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Models
{
    public class Object
    {
        public Object(AlgorithmParameters algorithmParameters)
        {
            ObjectCoefficients = new double[algorithmParameters.ObjectVectorSize];

            switch (algorithmParameters.TypeOfMutation)
            {
                case AlgorithmParameters.MutationType.UncorrelatedNSteps:
                    StdDeviationsCoefficients = new double[algorithmParameters.ObjectVectorSize];
                    break;
                case AlgorithmParameters.MutationType.Correlated:
                    StdDeviationsCoefficients = new double[algorithmParameters.ObjectVectorSize];
                    RotationsCoefficients = new double[algorithmParameters.ObjectVectorSize];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithmParameters.TypeOfMutation), algorithmParameters.TypeOfMutation, null);
            }
        }

        public double[] ObjectCoefficients { get; set; }
        public double[] StdDeviationsCoefficients { get; set; }
        public double[] RotationsCoefficients { get; set; }
        public double IndividualOneStepStdDeviation { get; set; }     
    }
}
