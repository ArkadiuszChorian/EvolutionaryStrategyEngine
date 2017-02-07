using System;

namespace EvolutionaryStrategyEngine.Utils
{
    public class AlgorithmParameters
    {
        public AlgorithmParameters(int objectVectorSize)
        {
            GlobalLearningRate = 1 / Math.Sqrt(2 * objectVectorSize);
            IndividualLearningRate = 1 / Math.Sqrt(2 * Math.Sqrt(objectVectorSize));
            StepThreshold = 0;
            RotationAngle = 5 * Math.PI / 180;
            NumberOfSolutionObjects = 1;
            ObjectVectorSize = objectVectorSize;
            TypeOfMutation = MutationType.Correlated;
        }
        public AlgorithmParameters(double globalLerningRate, double individualLearningRate, double stepThreshold, double rotationAngle, int numberOfSolutionObjects, int objectVectorSize, MutationType typeOfMutation)
        {
            GlobalLearningRate = globalLerningRate;
            IndividualLearningRate = individualLearningRate;
            StepThreshold = stepThreshold;
            RotationAngle = rotationAngle;
            NumberOfSolutionObjects = numberOfSolutionObjects;
            ObjectVectorSize = objectVectorSize;
            TypeOfMutation = typeOfMutation;
        }

        public enum MutationType
        {
            UncorrelatedOneGlobalStep,
            UncorrelatedOneIndividualStep,
            UncorrelatedNSteps,
            Correlated
        }
        public enum SelectionType
        {
            Distinct,
            Union
        }

        public double GlobalLearningRate { get; set; }
        public double IndividualLearningRate { get; set; }
        public double StepThreshold { get; set; }
        public double RotationAngle { get; set; }
        public int NumberOfSolutionObjects { get; set; }
        public int ObjectVectorSize { get; set; }
        public int NumberOfParentsSolutionsToSelect { get; set; }
        public int NumberOfSurvivorsSolutionsToSelect { get; set; }
        public MutationType TypeOfMutation { get; set; }      
    }
}
