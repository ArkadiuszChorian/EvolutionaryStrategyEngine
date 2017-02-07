using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Selection
{
    public interface ISelector
    {
        IEnumerable<Solution> Select(IEnumerable<Solution> solutions, int numberOfSelectedSolutions);
    }
}
