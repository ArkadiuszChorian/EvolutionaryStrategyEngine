using System.Collections.Generic;
using EvolutionaryStrategyEngine.Models;

namespace EvolutionaryStrategyEngine.Recombination
{
    public interface IRecombiner
    {
        Solution Recombine(IEnumerable<Solution> parents);
    }
}
