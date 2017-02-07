using System;
using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Mutation
{
    public class Mutator : IMutator
    {
        public Mutator(MutationType mutationType)
        {
            Mutations = new List<Func<Solution, Solution>>();

            switch (mutationType)
            {
                case MutationType.UncorrelatedOneStep:
                    Mutations.Add(MutationFunctions.MutateStdDeviationsCoefficientsWithOneStep);
                    break;
                case MutationType.UncorrelatedNSteps:
                    Mutations.Add(MutationFunctions.MutateStdDeviationsCoefficientsWithNSteps);
                    break;
                case MutationType.Correlated:
                    Mutations.Add(MutationFunctions.MutateStdDeviationsCoefficientsWithNSteps);
                    Mutations.Add(MutationFunctions.MutateRotationsCoefficients);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mutationType), mutationType, null);
            }

            Mutations.Add(MutationFunctions.MutateObjectCoefficients);
        }

        public List<Func<Solution, Solution>> Mutations { get; set; }
        public Solution Mutate(Solution solution)
        {
            foreach (var mutation in Mutations)
            {
                solution = mutation(solution);
            }

            return solution;
        }              
    }
}
