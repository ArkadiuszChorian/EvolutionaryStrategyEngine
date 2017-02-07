using System;
using System.Collections.Generic;
using EvolutionaryStrategyEngine.Evaluation;
using EvolutionaryStrategyEngine.Models;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Selection
{
    public class RandomParentsSelector : ISelector
    {       
        public IList<Solution> Select(IList<Solution> solutions, int numberOfSolutionsToSelect)
        {
            if (numberOfSolutionsToSelect == solutions.Count)
            {
                return solutions;
            }

            var selectedSolutions = new List<Solution>(numberOfSolutionsToSelect);

            for (var i = 0; i < numberOfSolutionsToSelect; i++)
            {
                //TODO: Solutions are taken with repetition       
                selectedSolutions[i] = solutions[MersenneTwister.Instance.Next(solutions.Count)];
            }

            return selectedSolutions;
        }
    }
}
