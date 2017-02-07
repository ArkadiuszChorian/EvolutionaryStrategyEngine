using System;
using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class Mutator : IMutator
    {       
        public Mutator(AlgorithmParameters algorithmParameters)
        {
            GlobalLearningRate = algorithmParameters.GlobalLearningRate;
            IndividualLearningRate = algorithmParameters.IndividualLearningRate;
            StepThreshold = algorithmParameters.StepThreshold;
            RotationAngle = algorithmParameters.RotationAngle;
            Mutations = new List<Func<Solution, Solution>>();

            switch (algorithmParameters.TypeOfMutation)
            {
                case AlgorithmParameters.MutationType.UncorrelatedOneGlobalStep:
                    Mutations.Add(MutateStdDeviationsWithOneGlobalStep);
                    Mutations.Add(MutateObjectsWithOneGlobalStep);
                    break;
                case AlgorithmParameters.MutationType.UncorrelatedOneIndividualStep:
                    Mutations.Add(MutateStdDeviationsWithOneIndividualStep);
                    Mutations.Add(MutateObjectsWithOneIndividualStep);
                    break;
                case AlgorithmParameters.MutationType.UncorrelatedNSteps:
                    Mutations.Add(MutateStdDeviationsWithNSteps);
                    Mutations.Add(MutateObjectsWithNStep);
                    break;
                case AlgorithmParameters.MutationType.Correlated:
                    Mutations.Add(MutateStdDeviationsWithNSteps);
                    Mutations.Add(MutateRotations);
                    Mutations.Add(MutateObjectsWithCorrelation);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithmParameters.TypeOfMutation), algorithmParameters.TypeOfMutation, null);
            }         
        }

        public double GlobalLearningRate { get; set; }
        public double IndividualLearningRate { get; set; }
        public double StepThreshold { get; set; }
        public double RotationAngle { get; set; }
        public List<Func<Solution, Solution>> Mutations { get; set; }

        public Solution Mutate(Solution solution)
        {
            foreach (var mutation in Mutations)
            {
                solution = mutation(solution);
            }

            return solution;
        }

        private Solution MutateStdDeviationsWithOneGlobalStep(Solution solution)
        {
            solution.GlobalOneStepStdDeviation *= Math.Exp(IndividualLearningRate * MersenneTwister.Instance.NextDoublePositive());

            solution.GlobalOneStepStdDeviation = CompareWithStepThreshold(solution.GlobalOneStepStdDeviation);

            return solution;
        }

        private Solution MutateStdDeviationsWithOneIndividualStep(Solution solution)
        {
            var numberOfObjects = solution.Objects.Length;

            for (var i = 0; i < numberOfObjects; i++)
            {
                solution.Objects[i].IndividualOneStepStdDeviation *= Math.Exp(IndividualLearningRate * MersenneTwister.Instance.NextDoublePositive());

                solution.Objects[i].IndividualOneStepStdDeviation = CompareWithStepThreshold(solution.Objects[i].IndividualOneStepStdDeviation);
            }

            return solution;
        }

        private Solution MutateStdDeviationsWithNSteps(Solution solution)
        {
            var numberOfObjects = solution.Objects.Length;           

            for (var i = 0; i < numberOfObjects; i++)
            {
                var numberOfCoefficients = solution.Objects[i].StdDeviationsCoefficients.Length;
                var currentObject = solution.Objects[i];

                for (var j = 0; j < numberOfCoefficients; j++)
                {
                    currentObject.StdDeviationsCoefficients[j] *= Math.Exp(IndividualLearningRate * MersenneTwister.Instance.NextDoublePositive() + GlobalLearningRate * MersenneTwister.Instance.NextDoublePositive());

                    currentObject.StdDeviationsCoefficients[j] = CompareWithStepThreshold(currentObject.StdDeviationsCoefficients[j]);
                }
            }

            return solution;
        }

        private Solution MutateRotations(Solution solution)
        {
            var numberOfObjects = solution.Objects.Length;

            for (var i = 0; i < numberOfObjects; i++)
            {
                var numberOfCoefficients = solution.Objects[i].RotationsCoefficients.Length;
                var currentObject = solution.Objects[i];

                for (var j = 0; j < numberOfCoefficients; j++)
                {
                    currentObject.RotationsCoefficients[j] += RotationAngle * MersenneTwister.Instance.NextDoublePositive();

                    if (Math.Abs(currentObject.RotationsCoefficients[j]) > Math.PI)
                    {
                        currentObject.RotationsCoefficients[j] -= 2 * Math.PI * Math.Sign(currentObject.RotationsCoefficients[j]);
                    }
                }
            }

            return solution;
        }

        private Solution MutateObjectsWithOneGlobalStep(Solution solution)
        {
            var numberOfObjects = solution.Objects.Length;

            for (var i = 0; i < numberOfObjects; i++)
            {
                var numberOfCoefficients = solution.Objects[i].ObjectCoefficients.Length;
                var currentObject = solution.Objects[i];

                for (var j = 0; j < numberOfCoefficients; j++)
                {
                    currentObject.ObjectCoefficients[j] += solution.GlobalOneStepStdDeviation * MersenneTwister.Instance.NextDoublePositive();
                }
            }

            return solution;
        }

        private Solution MutateObjectsWithOneIndividualStep(Solution solution)
        {
            var numberOfObjects = solution.Objects.Length;

            for (var i = 0; i < numberOfObjects; i++)
            {
                var numberOfCoefficients = solution.Objects[i].ObjectCoefficients.Length;
                var currentObject = solution.Objects[i];

                for (var j = 0; j < numberOfCoefficients; j++)
                {
                    currentObject.ObjectCoefficients[j] += currentObject.IndividualOneStepStdDeviation * MersenneTwister.Instance.NextDoublePositive();
                }
            }

            return solution;
        }

        private Solution MutateObjectsWithNStep(Solution solution)
        {
            var numberOfObjects = solution.Objects.Length;

            for (var i = 0; i < numberOfObjects; i++)
            {
                var numberOfCoefficients = solution.Objects[i].ObjectCoefficients.Length;
                var currentObject = solution.Objects[i];

                for (var j = 0; j < numberOfCoefficients; j++)
                {
                    currentObject.ObjectCoefficients[j] += currentObject.StdDeviationsCoefficients[j] * MersenneTwister.Instance.NextDoublePositive();
                }
            }

            return solution;
        }

        private Solution MutateObjectsWithCorrelation(Solution solution)
        {
            throw new NotImplementedException();
        }      

        private double CompareWithStepThreshold(double stdDeviation)
        {
            return stdDeviation < StepThreshold ? StepThreshold : stdDeviation;
        }
    }
}
