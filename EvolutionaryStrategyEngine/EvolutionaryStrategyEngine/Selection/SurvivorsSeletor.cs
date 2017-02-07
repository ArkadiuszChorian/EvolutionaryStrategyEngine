using System.Collections.Generic;
using System.Linq;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Selection
{
    public class SurvivorsSeletor : ISelector
    {
        public IList<Solution> Select(IList<Solution> solutions, int numberOfSolutionsToSelect)
        {
            return solutions.OrderByDescending(solution => solution.FitnessScore).Take(numberOfSolutionsToSelect).ToList();
        }
    }
}
