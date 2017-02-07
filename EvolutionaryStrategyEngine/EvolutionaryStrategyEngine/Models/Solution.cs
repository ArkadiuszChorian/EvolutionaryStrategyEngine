using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine.Models
{
    public class Solution
    {
        public Solution(AlgorithmParameters algorithmParameters)
        {
            Objects = new Object[algorithmParameters.NumberOfSolutionObjects];
        }

        public Object[] Objects { get; set; }
        public double GlobalOneStepStdDeviation { get; set; }
        public double FitnessScore { get; set; }
    }
}
