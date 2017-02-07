namespace EvolutionaryStrategyEngine.Models
{
    public class Solution
    {
        public Solution(int solutionSize)
        {
            Objects = new Object[solutionSize];
        }

        public Object[] Objects { get; set; }
        public double FitnessScore { get; set; }
    }
}
