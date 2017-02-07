using System;
using EvolutionaryStrategyEngine.Mutation;

namespace EvolutionaryStrategyEngine.Models
{
    public class Object
    {
        public Object(int objectVectorSize, MutationType mutationType)
        {
            ObjectCoefficients = new double[objectVectorSize];

            switch (mutationType)
            {
                case MutationType.UncorrelatedNSteps:
                    StdDeviationsCoefficients = new double[objectVectorSize];
                    break;
                case MutationType.Correlated:
                    StdDeviationsCoefficients = new double[objectVectorSize];
                    RotationsCoefficients = new double[objectVectorSize];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mutationType), mutationType, null);
            }
        }

        public double[] ObjectCoefficients { get; set; }
        public double[] StdDeviationsCoefficients { get; set; }
        public double[] RotationsCoefficients { get; set; }
        public double OneStepStdDeviation { get; set; }
    }
}
